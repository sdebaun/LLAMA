using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public delegate void PhaseChangeEventHandler(GamePhase phase);

public class GamePhase : NetworkBehaviour {

    public GameObject dayPhaseTitle;
    public Text dayPhaseTimer;
    public GameObject nightPhaseTitle;
    public Text spawnedCreepCount;
    public Text unspawnedCreepCount;

    public int secondsPerDay;
    public int creepsPerSpawnPerNight = 5;
    public float maxNightSpawnDuration = 20f;

    private int day = 0;

    [SyncVar(hook = "OnSecondsChange")]
    public int secondsLeft;
    private void OnSecondsChange(int s) {
        //dayPhaseTimer.text = secondsToFormattedTime(s);
    }

    [SyncVar(hook = "OnSpawnedCreepChange")]
    public int spawnedCreeps;
    public void OnSpawnedCreepChange(int i) {
        //spawnedCreepCount.text = "" + i;
    }

    [SyncVar(hook = "OnUnspawnedCreepChange")]
    public int unspawnedCreeps;
    public void OnUnspawnedCreepChange(int i) {
        //unspawnedCreepCount.text = "" + i;
    }

    [SyncVar(hook="OnPhaseChange")]
    public string phase;
    public event PhaseChangeEventHandler changeListeners;
    private void OnPhaseChange(string p) {
        if (p=="day" || p=="night") {
            // if (changeListeners != null) { changeListeners(this); } // not being used atm; how i *should* do it
            Application.UnloadLevel("ReadyRoomOverlay");
            bool isDay = (p == "day");
            dayPhaseTitle.SetActive(isDay);
            nightPhaseTitle.SetActive(!isDay);
        }
    }

    public override void OnStartClient() {
        OnPhaseChange(phase);
        OnSecondsChange(secondsLeft);
        OnSpawnedCreepChange(spawnedCreeps);
        OnUnspawnedCreepChange(unspawnedCreeps);
    }

    [Command]
    public void CmdSwitchTo(string newPhase) {
        SwitchTo(newPhase);
    }

    public void SwitchTo(string p) {
        phase = p;
        if (p == "day") { StartDay(); } else { StartNight(); }
    }

    IEnumerator CountDown() {
        while (secondsLeft>0) {
            yield return new WaitForSeconds(1);
            secondsLeft -= 1;
        }
        SwitchTo("night");
    }

    private void StartDay() {
        Debug.Log("Starting new day");
        day++;
        secondsLeft = secondsPerDay;
        StartCoroutine(CountDown());

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Creep")) { Destroy(g); }

        GameObject[] spawns = GameObject.FindGameObjectsWithTag("CreepSpawn");
        foreach (GameObject spawn in spawns) {
            spawn.GetComponent<CreepSpawn>().StopSpawning();
        }
    }
    private void StartNight() {
        Debug.Log("Starting new night");
        spawnedCreeps = unspawnedCreeps = 0;
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("CreepSpawn");
        Debug.Log("Found " + spawns.Length + " creep spawns.");
        foreach (GameObject spawn in spawns) {
            int creeps = creepsPerSpawnPerNight + day - 1;
            float spawnDuration = maxNightSpawnDuration + (day * 5);
            spawn.GetComponent<CreepSpawn>().SetSpawningLive(creeps, spawnDuration / creeps);
            unspawnedCreeps += creeps;
        }
    }

    public void trackCreepSpawn() {
        unspawnedCreeps--;
        spawnedCreeps++;
    }

    public void trackCreepDeath() {
        spawnedCreeps--;
        if ((spawnedCreeps==0) && (unspawnedCreeps==0)) { SwitchTo("day"); }
    }


    private string secondsToFormattedTime(int s) {
        string f = "";
        if (s > 60) { f += (int)(s / 60) + ":"; } else { f += "0:"; }
        int ss = s % 60;
        if (ss < 10) { f += "0"; }
        f += ss;
        return f;
    }


}

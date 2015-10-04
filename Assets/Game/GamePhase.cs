using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public delegate void PhaseChangeEventHandler(GamePhase phase);

public class GamePhase : NetworkBehaviour {

    // *Phase
    public GameObject dayPhaseTitle;
    public GameObject nightPhaseTitle;

    // DayPhase
    public int secondsPerDay;

    // NightPhase
    public int creepsPerSpawnPerNight = 5;
    public float maxNightSpawnDuration = 20f;

    private int day = 0;

    // DayPhase
    private Timer timer;

    // NightPhase
    [SyncVar]
    public int spawnedCreeps;

    // NightPhase
    [SyncVar]
    public int unspawnedCreeps;

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
    }

    public override void OnStartServer() {
        timer = GetComponent<Timer>();
    }

    [Command]
    public void CmdSwitchTo(string newPhase) {
        SwitchTo(newPhase);
    }

    public void SwitchTo(string p) {
        phase = p;
        if (p == "day") { StartDay(); } else { StartNight(); }
    }

    private void FinishDay() {
        SwitchTo("night");
    }

    private void StartDay() {
        Debug.Log("Starting new day");
        day++;

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Creep")) { Destroy(g); }

        GameObject[] spawns = GameObject.FindGameObjectsWithTag("CreepSpawn");
        foreach (GameObject spawn in spawns) {
            spawn.GetComponent<CreepSpawn>().StopSpawning();
        }

        timer.StartTimer(secondsPerDay, FinishDay);
    }
    private void StartNight() {
        Debug.Log("Starting new night");
        spawnedCreeps = unspawnedCreeps = 0;

        // SpawnManager.StartLive(), returns number of creeps queued
        // 
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

}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public delegate void PhaseChangeEventHandler(GamePhase phase);

public class GamePhase : NetworkBehaviour {

    public GameObject dayPhaseTitle;
    public Text dayPhaseTimer;
    public GameObject nightPhaseTitle;
    public Text nightPhaseCreepCounts;
    public int secondsPerDay;

    [SyncVar(hook="OnPhaseChange")]
    public string phase;
    public event PhaseChangeEventHandler changeListeners;
    private void OnPhaseChange(string p) {
        if (p=="day" || p=="night") {
            if (changeListeners != null) { changeListeners(this); } // not being used atm; how i *should* do it
            Application.UnloadLevel("ReadyRoomOverlay");
            bool isDay = (p == "day");
            dayPhaseTitle.SetActive(isDay);
            nightPhaseTitle.SetActive(!isDay);
        }
    }

    [SyncVar(hook = "OnSecondsChange")]
    public int secondsLeft;
    private void OnSecondsChange(int s) {
        if (secondsLeft != null) {
            dayPhaseTimer.text = secondsToFormattedTime(s);
        }
    }

    public override void OnStartClient() {
        OnPhaseChange(phase);
        OnSecondsChange(secondsLeft);
    }
    //void Start() {
    //    OnPhaseChange(phase);
    //    OnSecondsChange(secondsLeft);
    //}

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
        secondsLeft = secondsPerDay;

        StartCoroutine(CountDown());
    }
    private void StartNight() {
    }

    private string secondsToFormattedTime(int s) {
        string f = "";
        if (s > 60) { f += (int)(s / 60); } else { f += "0:"; }
        int ss = s % 60;
        if (ss < 10) { f += "0"; }
        f += ss;
        return f;
    }


}

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public delegate void PhaseChangeEventHandler(GamePhase phase);

public class GamePhase : NetworkBehaviour {

    public event PhaseChangeEventHandler changeListeners;

    public GameObject dayPhaseTitle;
    public GameObject nightPhaseTitle;

    [SyncVar(hook="OnPhaseChange")]
    public string phase;

    private void OnPhaseChange(string p) {
        if (changeListeners != null) { changeListeners(this); }
        Application.UnloadLevel("ReadyRoomOverlay");
        bool isDay = (p == "day");
        dayPhaseTitle.SetActive(isDay);
        nightPhaseTitle.SetActive(!isDay);
    }

    [Command]
    public void CmdSwitchTo(string newPhase) {
        phase = newPhase;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}

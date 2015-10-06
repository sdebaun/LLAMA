using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Phase : NetworkBehaviour {

    public Phase nextPhase;
    public GameController game;
    public GameObject ui;

    public virtual void OnBegin() { }
    public virtual void OnEnd() { }


    public void Begin() {
        Debug.Log("Beginning Phase " + this.name);
        uiActive = true;
        game.currentPhase = this;
        OnBegin();
    }

    public void End() {
        Debug.Log("Ending Phase " + this.name);
        uiActive = false;
        OnEnd();
    }

    public void Next() {
        Debug.Log("Going to Next Phase " + nextPhase.name);
        End();
        nextPhase.Begin();
    }

    [SyncVar(hook = "OnUIActive")]
    public bool uiActive;
    private void OnUIActive(bool b) {
        Debug.Log("OnUIActive " + b);
        ui.SetActive(b);
    }

    public override void OnStartClient() {
        OnUIActive(uiActive);
    }
}

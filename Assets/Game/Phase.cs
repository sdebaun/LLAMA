using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Phase : NetworkBehaviour {

    public Phase nextPhase;
    public GameObject ui;

    public virtual void OnBegin() { }
    public virtual void OnEnd() { }


    public void Begin() {
        Debug.Log("Beginning Phase " + this.name);
        uiActive = true;
        //ui.gameObject.SetActive(true);
        //GetComponent<NetworkActive>().SetActive(true);
        // you could have it find an animator and trigger a slide in animation?
        OnBegin();
    }

    public void End() {
        uiActive = false;
        //GetComponent<NetworkActive>().SetActive(false);
        OnEnd();
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

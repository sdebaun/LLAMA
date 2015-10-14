using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class Phase : NetworkBehaviour {

    public Phase nextPhase;
    public GameController game;
    //public GameObject ui;

    public List<GameObject> uiElements = new List<GameObject>();

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
        StartCoroutine( DelayedBegin() );
    }

    // this hacky bullshit ensures the "begin" syncvar of the next phase happens after the "end" syncvar of the current phase
    IEnumerator DelayedBegin() {
        yield return null;
        nextPhase.Begin();
    }

    [SyncVar(hook = "OnUIActive")]
    public bool uiActive;
    private void OnUIActive(bool b) {
        Debug.Log("OnUIActive " + name + ": " + b);
        foreach (GameObject ui in uiElements) {
            Animator a = ui.GetComponent<Animator>();
            if (a) {
                if (a.GetCurrentAnimatorStateInfo(0).IsName("Opened") && !b) {
                    if (!nextPhase.uiElements.Contains(ui)) a.SetTrigger("Close");
                } else if (a.GetCurrentAnimatorStateInfo(0).IsName("Closed") && b) a.SetTrigger("Open");
            } else {
                if (ui.activeSelf != b) ui.SetActive(b);
            }
        }
    }

    public override void OnStartClient() {
        OnUIActive(uiActive);
    }
}

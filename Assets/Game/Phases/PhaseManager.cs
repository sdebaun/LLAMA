using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PhaseManager : NetworkBehaviour {

    //public Phase[] phases;

    //[SyncVar(hook ="OnCurrentPhase")]
    //public NetworkInstanceId currentPhaseId;
    //private Phase currentPhase;
    //public void OnCurrentPhase(NetworkInstanceId newId) {
    //    if (newId) {
    //        currentPhase.End();
    //        currentPhase = ClientScene.FindLocalObject(newId);
    //        currentPhase.Begin();
    //    }
    //}

    //public override void OnStartClient() {
    //    OnCurrentPhase(currentPhaseId);
    //}

    //public override void OnStartServer() {
    //    phases[0].Activate();
    //}

}

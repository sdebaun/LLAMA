using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GameController : NetworkBehaviour {

    public Phase startingPhase;
    public Phase currentPhase;
    public Phase endPhase;

    public int turn = 0;

    public override void OnStartServer() {
        startingPhase.Begin();
    }

    [Server]
    public void End() {
        currentPhase.End();
        endPhase.Begin();
    }
}

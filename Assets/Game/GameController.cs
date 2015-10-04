using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GameController : NetworkBehaviour {

    public Phase startingPhase;

    public override void OnStartServer() {
        startingPhase.Begin();
    }

}

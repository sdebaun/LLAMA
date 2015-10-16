using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GameController : NetworkBehaviour {

    public PlayerListControl playerList;

    public Phase startingPhase;
    public Phase currentPhase;
    public Phase winPhase;
    public Phase losePhase;

    [SyncVar]
    public int turn = 0;

    public override void OnStartServer() {
        startingPhase.Begin();
    }

    [Server]
    public void Win() {
        currentPhase.End();
        winPhase.Begin();
    }
    
    [Server]
    public void Lose() {
        currentPhase.End();
        losePhase.Begin();
    }
}

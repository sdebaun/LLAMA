using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(SingleSpawner))]
public class ReadyRoomPhase : Phase {

    private SingleSpawner worldBuilder;
    //public CampManager camps;

    [Command] // this seems like a wack place to put this
    public void CmdStartGame() { End(); }

    public void Rebuild() { CmdRebuild(); }
    [Command] // this seems like a wack place to put this
    public void CmdRebuild() { worldBuilder.Respawn(); }

    public override void OnBegin() {
        worldBuilder = GetComponent<SingleSpawner>();
        worldBuilder.Respawn();// which will also turn on the ghost spawns? or --
        //camps.StartGhost();
    }

}

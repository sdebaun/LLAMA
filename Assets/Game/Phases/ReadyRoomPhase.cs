using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ReadyRoomPhase : Phase {

    public PositionSpawner worldSpawner;
    public RadiusSpawner campSpawner;

    [Command] // this seems like a wack place to put this
    public void CmdStartGame() { Next(); }

    public void Rebuild() { CmdRebuild(); }
    [Command] // this seems like a wack place to put this
    public void CmdRebuild() { worldSpawner.Respawn(); campSpawner.Respawn(); }

    public override void OnBegin() {
        worldSpawner.Respawn();// which will also turn on the ghost spawns? or --
        campSpawner.Respawn();
        //camps.StartGhost();
    }

}

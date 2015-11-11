using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Linq;

// used by gameobject with same name in World scene, child to Game
public class ReadyRoomPhase : Phase {

    public PositionSpawner worldSpawner;
    public RadiusSpawner campSpawner;
    public XenoController xenos;
    public FluffMaker fluff;

    [Command] // this seems like a wack place to put this
    public void CmdStartGame() { Next(); }

    public void Rebuild() { CmdRebuild(); }
    [Command] // this seems like a wack place to put this
    public void CmdRebuild() { RebuildAndStartGhosts(); }

    public override void OnBegin() { RebuildAndStartGhosts(); }

    private void RebuildAndStartGhosts() {
        fluff.Generate();
        //xenos.FindAllCamps().ForEach(item => item.DestroyAllSpawned());
        worldSpawner.Respawn();// which will also turn on the ghost spawns? or --
        //campSpawner.Respawn();
        //xenos.FindAllCamps().ForEach(item => item.BeginGhost());
    }

    public override void OnEnd() {
        //xenos.FindAllCamps().ForEach(item => item.End());
    }

}

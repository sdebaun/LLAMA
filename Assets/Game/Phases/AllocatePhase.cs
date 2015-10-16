using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AllocatePhase : Phase {

    public NetworkQuantity colonyResources;

    [Server]
    public override void OnBegin() {
        int perPlayer = (int)(colonyResources.amount / game.playerList.players.Count);
        foreach (PlayerModel p in game.playerList.players) {
            p.builder.builders[0].allowedBuilds = perPlayer;
            p.builder.builders[1].allowedBuilds += 1;
        }
        Next(3f);
    }

    [Server]
    public override void OnEnd() {
        //GameObject.Find("Sun").GetComponent<Sun>().enabled = false;
    }

}

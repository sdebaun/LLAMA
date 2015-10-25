using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// used by gameobject with same name in World scene, child to Game
public class AllocatePhase : Phase {

    public NetworkQuantity colonyResources;
    public NetworkToggle dayNightSounds;
    public WorldLightController worldLight;

    [Server]
    public override void OnBegin() {
        game.turn += 1;
        worldLight.RotateToSunset(game.secondsPerDay);
        dayNightSounds.value = true;
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

using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class NightPhase : Phase {

    public XenoController xenos;

    public int baseCreepsEachCamp = 1;
    public int extraCreepsEachCampPerDay = 4;

    public float baseSpawnDuration = 5f;
    public float extraSpawnDurationPerDay = 5f;

    [SyncVar]
    public int unspawnedCreeps;
    [SyncVar]
    public int spawnedCreeps;

    public override void OnBegin() {
        int creeps = baseCreepsEachCamp + (extraCreepsEachCampPerDay * game.turn);
        float spawnDuration = baseSpawnDuration + (extraSpawnDurationPerDay * game.turn);
        List<CampController> camps = xenos.FindAllCamps();
        foreach (CampController camp in xenos.FindAllCamps()) {
            camp.BeginLive(creeps, spawnDuration);
            camp.liveSpawner.countListeners += CountSpawn;
        }
        unspawnedCreeps = camps.Count * creeps;
    }

    private void CountSpawn() {
        unspawnedCreeps--; spawnedCreeps++;
    }

    public override void OnEnd() {
        // ???
    }
}

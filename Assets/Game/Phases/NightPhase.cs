using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using Pathfinding;

// used by gameobject with same name in World scene, child to Game
public class NightPhase : Phase {

    public IEnvironmentController environ;

    public int creepSpawnCountBase = 7;
    public int creepSpawnPerDay = 3;
    public float spawnDurationBase = 3f;
    public float spawnDurationPerDay = 1f;

    public XenoController xenos;
    public WorldLightController worldLight;
    public NetworkToggle dayNightSounds;

    public int baseCreepsEachCamp = 1;
    public int extraCreepsEachCampPerDay = 4;

    public float baseSpawnDuration = 5f;
    public float extraSpawnDurationPerDay = 5f;

    [SyncVar]
    public int unspawnedCreeps;
    [SyncVar]
    public int spawnedCreeps;

    private Object CounterLock = new Object();

    //[Server]
    public override void OnBegin() {
        Debug.Log("WAT2");
        environ.TransitionTo(EnvironmentState.Night);

        //dayNightSounds.value = false;
        //worldLight.RotateToMidnight(3f);
        //AstarPath.active.Scan();  // rebuild all navigation graphs
        //int creeps = baseCreepsEachCamp + (extraCreepsEachCampPerDay * game.turn);
        //float spawnDuration = baseSpawnDuration + (extraSpawnDurationPerDay * game.turn);
        //List<CampController> camps = xenos.FindAllCamps();
        //foreach (CampController camp in xenos.FindAllCamps()) {
        //    camp.BeginLive(creeps, spawnDuration);
        //    camp.liveSpawner.countListeners -= CountSpawn;
        //    camp.liveSpawner.countListeners += CountSpawn;
        //}
        //spawnedCreeps = 0;
        //unspawnedCreeps = camps.Count * creeps;
        //GameObject.Find("Moon").GetComponent<Light>().enabled = true;
    }

    public void CountSpawn() {
        lock (CounterLock) { // notsure if needed
            unspawnedCreeps--; spawnedCreeps++;
        }
    }

    public void CountDeath() {
        lock (CounterLock) { // notsure if needed
            spawnedCreeps--;
        }
        if ((spawnedCreeps <= 0)  && (unspawnedCreeps <= 0)) Next();
    }

    public override void OnEnd() {
        GameObject.Find("Moon").GetComponent<Light>().enabled = false;
    }
}

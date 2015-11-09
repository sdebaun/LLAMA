using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using Pathfinding;

// used by gameobject with same name in World scene, child to Game
public class NightPhase : Phase {

    public IEnvironmentController environ;
    public IXenoController xenos;

    public int creepSpawnCountBase = 7;
    public int creepSpawnPerDay = 3;
    public float spawnDurationBase = 3f;
    public float spawnDurationPerDay = 1f;

    public delegate void PathfindingScanDelegate();
    public PathfindingScanDelegate pathfindingScan; // = AstarPath.active.Scan;

    public delegate void NextPhaseDelegate();
    public NextPhaseDelegate goNextPhase;

    //public WorldLightController worldLight;
    //public NetworkToggle dayNightSounds;

    //public int baseCreepsEachCamp = 1;
    //public int extraCreepsEachCampPerDay = 4;

    //public float baseSpawnDuration = 5f;
    //public float extraSpawnDurationPerDay = 5f;

    [SyncVar]
    public int unspawnedCreeps;
    [SyncVar]
    public int spawnedCreeps;

    private Object CounterLock = new Object();

    public void Start() {
        environ = GameObject.Find("Environment").GetComponent<EnvironmentController>();
        xenos = GameObject.Find("Game").GetComponent<XenoController>();
    }

    //[Server]
    public override void OnBegin() {
        environ.TransitionTo(EnvironmentState.Night);
        unspawnedCreeps = creepSpawnCountBase + (creepSpawnPerDay * game.turn);
        xenos.StartSpawning(unspawnedCreeps, spawnDurationBase + (spawnDurationPerDay * game.turn));

        if (pathfindingScan == null) { pathfindingScan = AstarPath.active.Scan; }
        pathfindingScan.Invoke();
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
        if (goNextPhase == null) { goNextPhase = Next; }
        if ((spawnedCreeps <= 0) && (unspawnedCreeps <= 0)) goNextPhase();
    }

    //public override void OnEnd() {
    //    GameObject.Find("Moon").GetComponent<Light>().enabled = false;
    //}
}

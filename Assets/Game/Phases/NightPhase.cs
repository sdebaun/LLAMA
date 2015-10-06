using UnityEngine;
using System.Collections.Generic;

public class NightPhase : Phase {

    public XenoController xenos;

    public int baseCreepsEachCamp = 5;
    public int extraCreepsEachCampPerDay = 3;

    public float baseSpawnDuration = 15f;
    public float extraSpawnDurationPerDay = 6f;

    public override void OnBegin() {
        int creeps = baseCreepsEachCamp + (extraCreepsEachCampPerDay * game.turn);
        float spawnDuration = baseSpawnDuration + (extraSpawnDurationPerDay * game.turn);
        List<CampController> camps = xenos.FindAllCamps();
        camps.ForEach(item => item.BeginLive(creeps,spawnDuration));
        //int unspawnedCreeps = camps.Count * creeps;
    }

    public override void OnEnd() {
        // ???
    }
}

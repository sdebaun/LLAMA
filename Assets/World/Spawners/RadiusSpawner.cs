﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class RadiusSpawner : Spawner {

    public float minDistance;
    public float maxDistance;

    public override Vector3 NewSpawnPosition() {
        Vector2 randomPerimeterPosition = UnityEngine.Random.insideUnitCircle.normalized * Random.Range(minDistance,maxDistance);
        return new Vector3(randomPerimeterPosition.x, 0, randomPerimeterPosition.y);
    }

}

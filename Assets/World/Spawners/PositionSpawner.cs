using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PositionSpawner : Spawner {

    public Vector3 position;

    public override Vector3 NewSpawnPosition() {
        return position;
    }
}

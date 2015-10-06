using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CampController : NetworkBehaviour {

    public PeriodicSpawner ghostSpawner;
    public LimitedPeriodicSpawner liveSpawner;

    public void BeginLive(int count, float maxSpawnDuration) {
        ghostSpawner.End();
        DestroyAllSpawned();
        float maxSpawnInterval = maxSpawnDuration / count;
        liveSpawner.Begin(count, maxSpawnInterval * 0.5f, maxSpawnInterval);
    }

    public void DestroyAllSpawned() {
        liveSpawner.DestroySpawned();
        ghostSpawner.DestroySpawned();
    }

    public void BeginGhost() {
        liveSpawner.End();
        DestroyAllSpawned();
        ghostSpawner.Begin();
    }

    public void End() {
        ghostSpawner.End();
        liveSpawner.End();
        DestroyAllSpawned();
    }

}

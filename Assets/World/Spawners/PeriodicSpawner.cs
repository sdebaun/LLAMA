using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

// used
public class PeriodicSpawner : RadiusSpawner {

    public float minInterval = 1f;
    public float maxInterval = 2f;

    [Server]
    public virtual void Begin() { Begin(minInterval, maxInterval); }
    [Server]
    public void Begin(float newMinInterval, float newMaxInterval) {
        minInterval = newMinInterval; maxInterval = newMaxInterval;
        StartCoroutine(SpawnAfterDelay(minInterval,maxInterval));
    }

    IEnumerator SpawnAfterDelay(float min, float max) {
        while (true) {
            yield return new WaitForSeconds(Random.Range(min, max));
            SpawnOne();
        }
    }

    [Server]
    public void End() {
        StopAllCoroutines();
    }
}

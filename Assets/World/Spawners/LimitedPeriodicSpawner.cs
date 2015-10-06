using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class LimitedPeriodicSpawner : PeriodicSpawner {

    public int remaining;

    [Server]
    public override void Begin() { Begin(quantity, minInterval, maxInterval); }
    [Server]
    public void Begin(int newQuantity, float newMinInterval, float newMaxInterval) {
        remaining = quantity = newQuantity;
        countListeners -= CountSpawn;
        countListeners += CountSpawn;
        Begin(newMinInterval, newMaxInterval);
    }

    private void CountSpawn() {
        remaining -= 1;
        if (remaining <= 0) End();
    }
}

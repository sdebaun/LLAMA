using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class Spawner : NetworkBehaviour {

    public GameObject prefab;
    public int quantity = 1;

    public delegate void CountListener();
    public event CountListener countListeners;

    private List<GameObject> items = new List<GameObject>();

    [Server]
    public void Respawn() { Respawn(quantity); }

    [Server]
    public void Respawn(int newQuantity) {
        quantity = newQuantity;
        DestroySpawned();
        for (int i = 0; i < quantity; i++) SpawnOne();
    }

    [Server]
    public void DestroySpawned() {
        foreach (GameObject item in items) { Destroy(item); }
    }

    [Server]
    public void SpawnOne() {
        GameObject g = Instantiate(prefab, NewSpawnPosition(), NewSpawnRotation()) as GameObject;
        NetworkServer.Spawn(g);
        items.Add(g);
        if (countListeners != null) countListeners();
    }

    public virtual Vector3 NewSpawnPosition() {
        return transform.position;
    }

    public virtual Quaternion NewSpawnRotation() {
        return Quaternion.identity;
    }

}

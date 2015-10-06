using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class Spawner : NetworkBehaviour {

    public GameObject prefab;
    public int quantity = 1;

    private List<GameObject> items = new List<GameObject>();

    [Server]
    public void Respawn() { Respawn(quantity); }

    [Server]
    public void Respawn(int newQuantity) {
        quantity = newQuantity;
        foreach (GameObject item in items) { Destroy(item); }
        for (int i = 0; i < quantity; i++) {
            GameObject g = Instantiate(prefab, NewSpawnPosition(), NewSpawnRotation()) as GameObject;
            NetworkServer.Spawn(g);
            items.Add(g);
        }
    }

    public virtual Vector3 NewSpawnPosition() {
        return Vector3.zero;
    }

    public virtual Quaternion NewSpawnRotation() {
        return Quaternion.identity;
    }

}

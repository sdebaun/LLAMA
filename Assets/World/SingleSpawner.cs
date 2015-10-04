using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SingleSpawner : NetworkBehaviour {

    public GameObject prefab;

    private GameObject root;

    public void Respawn() {
        Destroy(root);
        root = Instantiate(prefab);
        NetworkServer.Spawn(root);
    }
}

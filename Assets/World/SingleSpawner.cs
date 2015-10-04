using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SingleSpawner : NetworkBehaviour {

    public GameObject prefab;

    private GameObject root;

    public void Respawn() {
        Destroy(root);
        root = Instantiate(prefab,Vector3.zero,Quaternion.identity) as GameObject;
        NetworkServer.Spawn(root);
    }
}

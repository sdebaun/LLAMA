using UnityEngine;
using UnityEngine.Networking;

public class TestSpawner : NetworkBehaviour {

    public override void OnStartServer() {
        GameObject g = Instantiate(Resources.Load("Entity/Creep/CreepPrefab"),Vector3.zero,Quaternion.identity) as GameObject;
        NetworkServer.Spawn(g);
    }

}
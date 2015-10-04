using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PopulateAll : NetworkBehaviour {

    public override void OnStartServer() {
        //NetworkServer.SpawnObjects();
        foreach (NetworkIdentity p in GetComponentsInChildren<NetworkIdentity>()) {
            NetworkServer.Spawn(p.gameObject);
        }
    }

    void Start() {
        if (isServer) {
            foreach (SelfPopulator p in GetComponentsInChildren<SelfPopulator>()) {
                p.Populate();
            }
        }
    }

}

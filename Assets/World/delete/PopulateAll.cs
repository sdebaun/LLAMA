using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PopulateAll : NetworkBehaviour {

    //public override void OnStartServer() {
    //    //NetworkServer.SpawnObjects();
    //    foreach (NetworkIdentity p in GetComponentsInChildren<NetworkIdentity>()) {
    //        NetworkServer.Spawn(p.gameObject);
    //    }
    //}

    //void Start() {
    //    if (isServer) {
    //        foreach (SelfPopulator p in GetComponentsInChildren<SelfPopulator>()) {
    //            p.Populate();
    //        }
    //    }
    //}

    //void Start() {
    //    if (isServer) {
    //        //NetworkIdentity[] children = GetComponentsInChildren<NetworkIdentity>();
    //        foreach (NetworkIdentity p in GetComponentsInChildren<NetworkIdentity>()) {
    //            Debug.Log("Found " + p.name);
    //            if (p.gameObject != gameObject) {
    //                Debug.Log("Spawning " + p.name);
    //                NetworkServer.Spawn(p.gameObject);
    //            }
    //        }
    //    }
    //}
}

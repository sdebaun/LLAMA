using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkPrefab : NetworkBehaviour {

    public GameObject realPrefab;

    void Start() {
        if (NetworkServer.active) {
            GameObject respawned = Instantiate(gameObject);
            respawned.GetComponent<NetworkPrefab>().enabled = false;
            NetworkServer.Spawn(respawned, realPrefab.GetComponent<NetworkIdentity>().assetId);
            //Debug.Log("Original asset id " + GetComponent<NetworkIdentity>().assetId);
            //Debug.Log("New asset id " + realPrefab.GetComponent<NetworkIdentity>().assetId);
            //NetworkServer.Spawn(gameObject, realPrefab.GetComponent<NetworkIdentity>().assetId);
        //} else {
        //    Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
}

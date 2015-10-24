using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CollisionTriggerDestroySelf : NetworkBehaviour {

    public SphereCollider targetingCollider;
    public int targetLayerID = 8;

    void Start() {
        //print("CollisionTriggerDestroySelf: " + gameObject.name);
        if (!isServer) targetingCollider.enabled = false;
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == targetLayerID) Destroy(gameObject);
    }

}

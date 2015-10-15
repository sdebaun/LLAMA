using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TriggerTarget : NetworkBehaviour {

    //public Attack attack;
    public int targetLayerID = 8;

    private SphereCollider targetingCollider;

    void Start() {
        targetingCollider = GetComponent<SphereCollider>();
        if (isClient) { // disable targeting entirely
            gameObject.SetActive(false);
            targetingCollider.enabled = false;
        }
    }

    public void OnTriggerEnter(Collider other) {
        //if (!attack.target && (other.gameObject.layer == targetLayerID)) { attack.setTarget(other.gameObject); }
    }

    public void findNearbyTarget() {
        // find others with my own collider's radius that match the specified layer id
        Collider[] colliders = Physics.OverlapSphere(transform.position, targetingCollider.radius, 1 << targetLayerID);
        // just target the first one in the list for now
        //if (colliders.Length > 0) { attack.setTarget(colliders[0].gameObject); }
    }


}

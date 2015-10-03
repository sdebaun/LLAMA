using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TriggerTarget : NetworkBehaviour {

    public int targetLayerID = 8;
    private SphereCollider targetingCollider;

    public Attack attack;

    void Start() {
        targetingCollider = GetComponent<SphereCollider>();
        if (isClient) { // disable targeting
            gameObject.SetActive(false);
            targetingCollider.enabled = false;
        }
    }

    public void OnTriggerEnter(Collider other) {
        Debug.Log("Triggered by " + other.gameObject.name + " layer " + other.gameObject.layer);
        if (!attack.target && (other.gameObject.layer == targetLayerID)) { attack.setTarget(other.gameObject); }
    }

    public void findNearbyTarget() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, targetingCollider.radius, 1 << targetLayerID);
        if (colliders.Length > 0) {
            Debug.Log("Found nearby target on-demand");
            attack.setTarget(colliders[0].gameObject);
        }
    }


}

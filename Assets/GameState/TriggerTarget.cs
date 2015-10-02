using UnityEngine;
using System.Collections;

public class TriggerTarget : MonoBehaviour {

    public int targetLayerID = 8;

    public Attack attack;

    public void OnTriggerEnter(Collider other) {
        Debug.Log("Triggered by " + other.gameObject.name + " layer " + other.gameObject.layer);
        if (!attack.hasTarget && (other.gameObject.layer == targetLayerID)) { attack.setTarget(other.gameObject); }
    }

}

using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public bool hasTarget = false;
    public GameObject target;

    public TriggerTarget targeter;

    public float maxLockDistance = 3f;

    public LineRenderer pewpew;

    void Start() { pewpew.SetWidth(0.2f, 0.1f); }

    void Update() {
        if ((target == null) || (distanceToTarget()> maxLockDistance) ) {
            clearTarget();
            targeter.findNearbyTarget();
        }
        if (hasTarget) {
            pewpew.SetPosition(0, transform.position);
            pewpew.SetPosition(1, target.transform.position);
        }
    }

    public float distanceToTarget() {
        return target ? Vector3.Distance(transform.position, target.transform.position) : 0f;
    }

    public void setTarget(GameObject g) {
        hasTarget = true;
        target = g;
        pewpew.enabled = true;
    }

    public void clearTarget() {
        hasTarget = false;
        target = null;
        pewpew.enabled = false;
    }

}

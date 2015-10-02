﻿using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public bool hasTarget = false;
    public GameObject target;

    public float maxLockDistance = 6f;

    public LineRenderer pewpew;

    void Update() {
        if ((target == null) || (distanceToTarget()> maxLockDistance) ) { clearTarget(); }
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
    }

    public void clearTarget() {
        hasTarget = false;
        target = null;
    }

}

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;

[Serializable]
public class CollisionEvent : UnityEvent<GameObject,int> { }

[RequireComponent(typeof(Collider))]
public class FilteredCollisionBroadcaster : MonoBehaviour {

    public LayerMask layerMask;
    public int priority = 0; // specific to the event handler

    public CollisionEvent onEnter;
    public CollisionEvent onExit;

    public void OnTriggerEnter(Collider other) {
        if ((layerMask.value & 1<<other.gameObject.layer) != 0) onEnter.Invoke(other.gameObject, priority);
    }

    public void OnTriggerExit(Collider other) {
        if ((layerMask.value & 1 << other.gameObject.layer) != 0) onExit.Invoke(other.gameObject, priority);
    }

}

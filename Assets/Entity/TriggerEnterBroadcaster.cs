using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

/*
used in: TriggerTargetCreeps, part of the player prefab
When gameobjects ENTER the collider trigger on this gameobject, this broadcasts to its listeners.
Gameobjects must be on a layer listed in filter.
Collider must be marked "Trigger" or Unity wont fire triggers.
*/
public class TriggerEnterBroadcaster : TriggerBroadcaster {

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    [Server]
    public void OnTriggerEnter(Collider other) {
        BroadcastIfUnfiltered(other.gameObject, priority);
    }

}

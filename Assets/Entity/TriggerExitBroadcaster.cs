using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

/*
When gameobjects EXIT the collider trigger on this gameobject, this broadcasts to its listeners.
Gameobjects must be on a layer listed in filter.
Collider must be marked "Trigger" or Unity wont fire triggers.
*/
public class TriggerExitBroadcaster : TriggerBroadcaster {

    public void OnTriggerExit(Collider other) {
        BroadcastIfUnfiltered(other.gameObject, priority);
    }

}

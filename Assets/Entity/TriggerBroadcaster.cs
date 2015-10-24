using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

/*
used in: TriggerTargetCreeps, part of the player prefab
Base class for trigger broadcasters
*/
public class TriggerBroadcaster : NetworkBehaviour {

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    public TriggerLayerFilter filter;
    public int priority = 0; // sent along with event

    public delegate void TriggerListener(GameObject other, int priority);
    public event TriggerListener listeners;

    public void BroadcastIfUnfiltered(GameObject g, int p) {
        if (filter.layers.Contains(g.layer) && (listeners != null)) listeners(g, priority);
    }
}

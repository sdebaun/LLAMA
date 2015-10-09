using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

/*
Base class for trigger broadcasters
*/
public class TriggerBroadcaster : NetworkBehaviour {

    public TriggerLayerFilter filter;
    public int priority = 0; // sent along with event

    public delegate void TriggerListener(GameObject other, int priority);
    public event TriggerListener listeners;

    public void BroadcastIfUnfiltered(GameObject g, int p) {
        if (filter.layers.Contains(g.layer) && (listeners != null)) listeners(g, priority);
    }
}

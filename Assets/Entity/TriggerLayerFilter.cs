using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

/*
Provides a list of layers (compiled into a layermask) for use by Trigger scripts.
*/
public class TriggerLayerFilter : NetworkBehaviour {

    public List<int> layers = new List<int>();
    public int layerMask = 1; // actually may not need this at all lol.

    void Start() {
        if (enabled = isServer) { // YES THAT IS AN ASSIGNMENT
            foreach (int layer in layers) { layerMask = layerMask << layer; } // for use in Physics.OverlapSphere
        }
    }

}

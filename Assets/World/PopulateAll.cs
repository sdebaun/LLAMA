using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PopulateAll : NetworkBehaviour {

    public override void OnStartServer() {
        foreach (SelfPopulator p in GetComponentsInChildren<SelfPopulator>()) { p.Populate(); }
    }

}

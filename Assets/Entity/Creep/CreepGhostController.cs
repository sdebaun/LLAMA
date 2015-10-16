using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CreepGhostController : NetworkBehaviour {

    public Animation legacyAnimation;

    void Start() {
        if (isClient) {
            legacyAnimation.Play("walk");
        }
    }
}

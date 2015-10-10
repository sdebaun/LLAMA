using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CreepGhostController : NetworkBehaviour {

    public NavMeshAgent agent;
    public string destinationName;

    public Animation legacyAnimation;

    void Start() {
        if (isServer) agent.SetDestination(GameObject.Find(destinationName).transform.position);
        if (isClient) {
            legacyAnimation.Play("walk");
        }
    }
}

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CreepGhostController : NetworkBehaviour {

    public NavMeshAgent agent;
    public string destinationName;

    void Start() {
        if (isServer) agent.SetDestination(GameObject.Find(destinationName).transform.position);
    }
}

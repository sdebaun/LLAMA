using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class FixedNavigator : NetworkBehaviour {

    public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    public GameObject destination;
    public NavMeshAgent agent;

    void Start() {
        if (isServer) agent.SetDestination(destination.transform.position);
    }

}

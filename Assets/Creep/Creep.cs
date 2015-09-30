using UnityEngine;
using System.Collections;

public class Creep : MonoBehaviour {

    public Transform goal;

    NavMeshAgent agent;

    private Transform target;

    // Use this for initialization
    void Start () {
        target = goal;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}

using UnityEngine;
using System.Collections;

public class Creep : MonoBehaviour {

    public Transform goal;
    public float nav_wait;

    NavMeshAgent agent;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        GameObject goalGameObject = GameObject.Find("Goal");
        agent.destination = goalGameObject.transform.position;
	}


	
    // Update is called once per frame
	void Update () {
	    
	}
}

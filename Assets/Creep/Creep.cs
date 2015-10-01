using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Creep : NetworkBehaviour {

    public float nav_wait;
    public bool isGhost = false;
    public float ghostDestructDistance = 1.5f;

    NavMeshAgent agent;
    private GameObject goal;

    // Use this for initialization
    void Start () {
        if (isServer) {
            agent = GetComponent<NavMeshAgent>();
            goal = GameObject.Find("Goal");
            agent.destination = goal.transform.position;
        }
    }


	
    // Update is called once per frame
	void Update () {
        if (isGhost) {
            if (Vector3.Distance(transform.position,goal.transform.position) < ghostDestructDistance) {
                Destroy(gameObject);
            }
        }
	    
	}
}

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Creep : NetworkBehaviour {

    // when you start, randomly set your speed
    public float minSpeed = 0.5f;
    public float maxSpeed = 1.5f;

    // when in ghost mode, destroy yourself if this close to goal
    public float ghostDestructDistance = 1.5f;

    // set by spawner if in ghost mode (during ready room)
    public bool isGhost = false;

    // cached references
    private NavMeshAgent agent;
    private GameObject goal;
    private GamePhase phase;

    void Start () {
        if (isServer) {
            phase = GameObject.Find("GameManager").GetComponent<GamePhase>();
            agent = GetComponent<NavMeshAgent>();
            goal = GameObject.Find("Goal");
            agent.destination = goal.transform.position;
            agent.speed = Random.Range(minSpeed, maxSpeed);
        }
    }

	void Update () {
        if (isServer && isGhost) {
            if (Vector3.Distance(transform.position,goal.transform.position) < ghostDestructDistance) {
                Destroy(gameObject);
            }
        }	    
	}

    void OnDestroy() {
        if (NetworkServer.active && !isGhost) { // isServer is not active because this is run after death of NetworkIdentity
            phase.trackCreepDeath();
        }
    }
}

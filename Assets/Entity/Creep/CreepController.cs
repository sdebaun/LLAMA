using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CreepController : NetworkBehaviour {


    public NavMeshAgent agent;
    public string destinationName;
    public Damageable damage;

    private NightPhase night;

    void Start() {
        if (isServer) {
            night = GameObject.Find("NightPhase").GetComponent<NightPhase>();
            damage.killListeners += ()=>{ night.CountDeath(); };
            agent.SetDestination(GameObject.Find(destinationName).transform.position);
            agent.speed = agent.speed * Random.Range(0.5f, 1.5f);
        }
    }
}

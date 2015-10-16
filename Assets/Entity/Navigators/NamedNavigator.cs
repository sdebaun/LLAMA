using UnityEngine;
using UnityEngine.Networking;

public class NamedNavigator : NetworkBehaviour {

    public string destinationName;
    public NavMeshAgent agent;
    public float moveSpeedMax =0.5f, moveSpeedMin =1.0f;

    void Start() {
        if (isServer) {
            agent.SetDestination(GameObject.Find(destinationName).transform.position);
            agent.speed = Random.Range(moveSpeedMax, moveSpeedMin);
        }
    }

}

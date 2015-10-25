using UnityEngine;
using UnityEngine.Networking;

// used in creepghost
public class NamedNavigator : NetworkBehaviour {

    public string destinationName;
    public NavMeshAgent agent;
    public float moveSpeedMax =0.5f, moveSpeedMin =1.0f;

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    void Start() {
        if (isServer) {
            agent.SetDestination(GameObject.Find(destinationName).transform.position);
            agent.speed = Random.Range(moveSpeedMax, moveSpeedMin);
        }
    }

}

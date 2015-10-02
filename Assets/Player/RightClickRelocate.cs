using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class RightClickRelocate : NetworkBehaviour {

    public GameObject moveGoalObject;

    private NavMeshAgent agent;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        moveGoalObject.transform.SetParent(null);
	}
	
	void Update () {
	    if (isLocalPlayer) {
            if (Input.GetMouseButtonUp(1)) {
                Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                moveGoalObject.transform.position = new Vector3(mPos.x, 0f, mPos.z);
                agent.destination = moveGoalObject.transform.position;
            }
        }
	}
}

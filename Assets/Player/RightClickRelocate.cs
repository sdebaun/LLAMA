using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class RightClickRelocate : NetworkBehaviour {

    public GameObject moveGoalPrefab;

    public GameObject moveGoalObject;

    public float stopDistance = 0.1f;

    private NavMeshAgent agent;
    private PlayerModel player;

	void Start () {
        if (isServer) {
            player = GetComponent<PlayerModel>();
            agent = GetComponent<NavMeshAgent>();
            agent.stoppingDistance = stopDistance;
            Debug.Log("Creating moveGoalObject on server");
            moveGoalObject = Instantiate(moveGoalPrefab) as GameObject;
            NetworkServer.Spawn(moveGoalObject);
            moveGoalObject.SetActive(false);
            moveGoalObject.GetComponent<SpriteRenderer>().color = player.color;
        }

    }
	
	void Update () {
	    if (isLocalPlayer) {
            if (Input.GetMouseButtonUp(1)) {
                Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                CmdMoveTarget(new Vector3(mPos.x, 0f, mPos.z));
            }
        }
        if (isServer && moveGoalObject.activeSelf) {
            if (Vector3.Distance(moveGoalObject.transform.position, transform.position) <= stopDistance) {
                moveGoalObject.GetComponent<ServerDeactivate>().ServerSetActive(false);
            }
        }
	}

    [Command]
    public void CmdMoveTarget(Vector3 p) {
        moveGoalObject.GetComponent<ServerDeactivate>().ServerSetActive(true);
        moveGoalObject.transform.position = p;
        agent.destination = p;
    }

}

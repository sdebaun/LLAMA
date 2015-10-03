using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class RightClickRelocate : NetworkBehaviour {

    public GameObject moveGoalPrefab;

    public GameObject moveGoalObject;

    public float stopDistance = 0.1f;

    private NavMeshAgent agent;
    private PlayerModel player;

    private AudioSource footsteps;
    private Rigidbody rigidbody;

	void Start () {
        if (isServer) {
            player = GetComponent<PlayerModel>();
            agent = GetComponent<NavMeshAgent>();
            agent.stoppingDistance = stopDistance;

            Debug.Log("Creating moveGoalObject on server");
            moveGoalObject = Instantiate(moveGoalPrefab) as GameObject;
            NetworkServer.Spawn(moveGoalObject);
            moveGoalObject.GetComponent<ServerDriven>().SetSpriteColor(player.color);
            moveGoalObject.GetComponent<ServerDriven>().SetActive(false);
        }
        if (isClient) {
            footsteps = GetComponent<AudioSource>();
            rigidbody = GetComponent<Rigidbody>();
        }
    }
	
	void Update () {
	    if (isLocalPlayer) {
            if (Input.GetMouseButtonUp(1)) {
                Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                CmdMoveTarget(new Vector3(mPos.x, 0f, mPos.z));
            }
        }
        if (isClient) {
            if (!footsteps.isPlaying && (agent.remainingDistance > 0.1f))
                footsteps.Play();
            if (footsteps.isPlaying && (agent.remainingDistance < 0.1f))
                footsteps.Stop();
        }
        if (isServer && moveGoalObject.activeSelf) {
            if (Vector3.Distance(moveGoalObject.transform.position, transform.position) <= stopDistance) {
                moveGoalObject.GetComponent<ServerDriven>().SetActive(false);
            }
        }
	}

    [Command]
    public void CmdMoveTarget(Vector3 p) {
        moveGoalObject.GetComponent<ServerDriven>().SetActive(true);
        moveGoalObject.transform.position = p;
        agent.destination = p;
    }

}

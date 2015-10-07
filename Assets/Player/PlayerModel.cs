using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PlayerModel : NetworkBehaviour {

    public RandomColor playerColor;
    public NetworkMeshColor meshColor;
    public NavMeshAgent agent;

    public GameObject moveTargetPrefab;
    private GameObject moveTarget;

    public List<Builder> builders;
    public Builder currentBuilder;

    void Update() {
        if (isLocalPlayer) {
            foreach (Builder b in builders) {
                if (Input.GetKeyDown(b.toggleKey)) ToggleBuildMode(b);
            }
        }
    }

    void ToggleBuildMode(Builder b) {
        if (currentBuilder == b) {
            currentBuilder.Off();
            currentBuilder = null;
        } else {
            if (currentBuilder) currentBuilder.Off();
            if (b) b.On();
            currentBuilder = b;
        }
    }

    public override void OnStartServer() {
        Debug.Log("PlayerModel.OnStartServer");
        playerColor.changeListeners += ColorChange;
    }

    private void ColorChange(Color c) {
        meshColor.color = c;
        if (moveTarget) moveTarget.GetComponent<NetworkSpriteColor>().color = c;
    }

    public override void OnStartLocalPlayer() { // connect ui/camera/etc to this thing
        Debug.Log("PlayerModel.OnStartLocalPlayer");
        GetComponent<FollowCam>().enabled = true;
        GameObject ground = GameObject.Find("Ground"); // brittle
        if (ground) ground.GetComponent<PlayerClickHandler>().localPlayer = this;
    }

    [Client]
    public void HandlePointerEvent(PointerEventData p) {
        Vector3 worldPosition = p.pointerPressRaycast.worldPosition; // it hits ground at collider edge
        Debug.Log("mouse button " + p.button + " at screen " + p.position + " world " + worldPosition);
        if (p.button == PointerEventData.InputButton.Left) {
            if (currentBuilder && currentBuilder.CanBuild()) CmdPlaceTower(builders.IndexOf(currentBuilder), currentBuilder.GetBuildPosition());
        } else if (p.button == PointerEventData.InputButton.Right) {
            CmdSetDestination(worldPosition);
            ToggleBuildMode(null);
        }
    }

    [Command]
    private void CmdPlaceTower(int builderIndex, Vector3 position) {
        print("Building index " + builderIndex);
        builders[builderIndex].Spawn(position);
        //GameObject g = Instantiate(towerPrefab, position, Quaternion.identity) as GameObject;
        //NetworkServer.Spawn(g);
        //towerBuilds--;
    }

    [Command]
    private void CmdSetDestination(Vector3 dest) {
        moveTarget.transform.position = dest;
        agent.SetDestination(dest);
    }

    void Start () { // simulation and ui setup
        Debug.Log("PlayerModel.Start");
        if (isServer) {
            moveTarget = Instantiate<GameObject>(moveTargetPrefab);
            moveTarget.GetComponent<NetworkSpriteColor>().color = playerColor.color;
            NetworkServer.Spawn(moveTarget);
        } else {
            agent.enabled = false;
        }

        // adding myself to the player list UI -- decouple this!!!
        if (isClient) AddToUI();
    }

    public override void OnNetworkDestroy() {
        players.Remove(this);
        Destroy(moveTarget); // because it was created independently
    }

    private PlayerListControl players; // gotta decouple this dammit
    public void AddToUI() {
        GameObject go = GameObject.Find("PlayerList");
        players = go.GetComponent<PlayerListControl>();
        if (players) {
            players.Add(this);
            if (!isLocalPlayer) {
                gameObject.GetComponent<FollowCam>().enabled = false;
            }
        }
    }


}

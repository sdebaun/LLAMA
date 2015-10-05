using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PlayerModel : NetworkBehaviour {

    public RandomColor playerColor;
    public MeshRenderer[] playerMeshes;

    private PlayerListControl players; // gotta decouple this dammit

    public override void OnStartServer() {
        Debug.Log("PlayerModel.OnStartServer (should be server)");
    }

    public override void OnStartLocalPlayer() { // connect ui/camera/etc to this thing
        Debug.Log("PlayerModel.OnStartLocalPlayer");
        GameObject ground = GameObject.Find("Ground"); // brittle
        if (ground!=null) ground.GetComponent<PlayerClickHandler>().localPlayer = this;
    }

    public override void OnStartClient() {
        // should issue server command to set name from readyroom ui element
        if (playerColor != null) {
            ChangedColor(playerColor.color);
            //playerColor.changeListeners += ChangedColor;
        }
    }

    private void ChangedColor(Color c) {
        Debug.Log("PlayerModel.ChangedColor");
        foreach (MeshRenderer m in playerMeshes) {
            m.material.color = playerColor.color;
        }
    }

    [Client]
    public void HandlePointerEvent(PointerEventData p) {
        Vector3 worldPosition = p.pointerPressRaycast.worldPosition; // it hits ground at y=0 so no tweaking needed
        Debug.Log("mouse button " + p.button + " at screen " + p.position + " world " + worldPosition);
        if (p.button == PointerEventData.InputButton.Left) CmdPlaceTower(worldPosition);
        else if (p.button == PointerEventData.InputButton.Right) CmdSetDestination(worldPosition);
    }

    [Command]
    private void CmdPlaceTower(Vector3 position) {

    }

    [Command]
    private void CmdSetDestination(Vector3 dest) {

    }

    void Start () {
        Debug.Log("PlayerModel.Start");
        // adding myself to the player list UI -- decouple this!!!
        GameObject go = GameObject.Find("PlayerList");
        players = go.GetComponent<PlayerListControl>();
        if (players) {
            players.Add(this);
            if (!isLocalPlayer) {
                gameObject.GetComponent<FollowCam>().enabled = false;
            }
        }
    }

    public override void OnNetworkDestroy() {
        players.Remove(this);
        if (isServer) {
            Destroy(gameObject.GetComponentInChildren<RightClickRelocate>().moveGoalObject);
        }
    }

}

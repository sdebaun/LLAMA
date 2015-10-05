using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerModel : NetworkBehaviour {

    [SyncVar]
    public Color color;

    private PlayerListControl players;

    public override void OnStartAuthority() {
        Debug.Log("PlayerModel.OnStartAuthority (should be server)");
        color = newRandomColor();
        gameObject.GetComponent<ServerDriven>().SetMeshColor(color);
    }

    public override void OnStartLocalPlayer() { // connect ui/camera/etc to this thing
        Debug.Log("PlayerModel.OnStartLocalPlayer");
        GameObject ground = GameObject.Find("Ground"); // brittle
        if (ground!=null) ground.GetComponent<PlayerClickHandler>().localPlayer = this;
    }

    [Client]
    public void HandlePointerEvent(PointerEventData p) {
        Vector3 worldPosition = p.pointerPressRaycast.worldPosition;
        //worldPosition.y = 0;
        Debug.Log("mouse button " + p.button + " at screen " + p.position + " world " + worldPosition);
        if (p.button == PointerEventData.InputButton.Left) {
        } else if (p.button == PointerEventData.InputButton.Right) {
        }
    }

    [Server]
    private Color newRandomColor() {
        float[] c = { Random.Range(0.3f, 0.5f), Random.Range(0.3f, 0.5f), Random.Range(0.3f, 0.5f) };
        c[Random.Range(0, 3)] += Random.Range(0.4f, 0.5f);
        return new Color(c[0],c[1],c[2]);
    }

    void Start () {
        Debug.Log("PlayerModel.Start");
        // gotta be a better way to do this
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

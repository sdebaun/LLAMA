using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkParent : NetworkBehaviour {

    [Server]
    public void SetParent(GameObject g) {
        //Debug.Log(name + ":NetworkParent.SetParent with " + g);
        transform.SetParent(g ? g.transform : null); // sets it on server
        serverParentId = g ? g.GetComponent<NetworkIdentity>().netId : NetworkInstanceId.Invalid; // to trigger client
    }

    [SyncVar(hook = "OnParent")]
    public NetworkInstanceId serverParentId = NetworkInstanceId.Invalid;
    private void OnParent(NetworkInstanceId id) {
        gameObject.transform.SetParent( id!=NetworkInstanceId.Invalid ? ClientScene.FindLocalObject(id).transform : null );
    }


    //public override void OnStartClient() { // newly connected clients should update
    //    Debug.Log(name + ":NetworkParent.OnStartClient with " + serverParentId);
    //    if (!isServer) OnParent(serverParentId); // server should not
    //}

    void Start() {
        //Debug.Log(name + ":NetworkParent.Start with " + serverParentId);
        if (!isServer) OnParent(serverParentId); // newly connected clients should update, server should not
    }
}

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkParent : NetworkBehaviour {

    [Server]
    public void SetParent(GameObject g) {
        transform.SetParent(g.transform); // sets it on server
        serverParentId = g.GetComponent<NetworkIdentity>().netId; // to trigger client
    }

    [SyncVar(hook = "OnParent")]
    public NetworkInstanceId serverParentId;
    private void OnParent(NetworkInstanceId id) {
        if (!id.IsEmpty())
            gameObject.transform.SetParent(ClientScene.FindLocalObject(id).transform);
    }


    public override void OnStartClient() { // newly connected clients should update
        if (!isServer) OnParent(serverParentId); // server should not
    }
}

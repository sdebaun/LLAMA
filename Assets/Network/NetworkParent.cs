using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkParent : NetworkBehaviour {

    [SyncVar(hook = "OnParent")]
    public NetworkInstanceId serverParentId;
    private void OnParent(NetworkInstanceId id) {
        Debug.Log("OnParent" + id.Value);
        if (!id.IsEmpty()) gameObject.transform.SetParent(ClientScene.FindLocalObject(id).transform);
    }

    [Server]
    public void SetParent(Transform t) {
        Debug.Log("Set network parent of " + name + " to id of " + t.name + ": " + serverParentId);
        NetworkIdentity ni = t.gameObject.GetComponent<NetworkIdentity>();
        Debug.Log("isServer, isClient: " + isServer + ", " + isClient);
        transform.SetParent(t);
        serverParentId = t.gameObject.GetComponent<NetworkIdentity>().netId;
    }

    //public override void OnStartClient() {
    //    OnParent(serverParentId);
    //}
}

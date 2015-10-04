using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkParent : NetworkBehaviour {

    [SyncVar(hook = "OnParent")]
    public NetworkInstanceId serverParentId;
    private void OnParent(NetworkInstanceId id) {
        Debug.Log("OnParent of " + name + " called with " + id);
        if (!id.IsEmpty()) {
            gameObject.transform.SetParent(ClientScene.FindLocalObject(id).transform);
        }
    }

    [Server]
    public void SetParent(GameObject g) {
        Debug.Log("Setting network parent of " + name + " to id of " + g.name + ": " + g.GetComponent<NetworkIdentity>().netId);
        transform.SetParent(g.transform);
        serverParentId = g.GetComponent<NetworkIdentity>().netId;
    }
    //public void SetParent(Transform t) {
    //    NetworkIdentity ni = t.gameObject.GetComponent<NetworkIdentity>();
    //    Debug.Log("Parent isServer, isClient: " + ni.isServer + ", " + ni.isClient);
    //    Debug.Log("Setting network parent of " + name + " to id of " + t.name + ": " + t.gameObject.GetComponent<NetworkIdentity>().netId);
    //    transform.SetParent(t);
    //    serverParentId = t.gameObject.GetComponent<NetworkIdentity>().netId;
    //}

    public override void OnStartClient() {
        OnParent(serverParentId);
    }
}

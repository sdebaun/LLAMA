using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ServerDeactivate : NetworkBehaviour {

    public void ServerSetActive(bool b) {
        gameObject.SetActive(b);
        RpcSetActive(b);
    }

    [ClientRpc]
    public void RpcSetActive(bool b) {
        Debug.Log("Setting active on client to " + b);
        gameObject.SetActive(b);
    }
}

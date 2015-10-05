using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkActive : NetworkBehaviour {

    //[SyncVar(hook = "OnActive")]
    //public bool serverActive;
    //private void OnActive(bool b) {
    //    Debug.Log("OnActive " + b);
    //    gameObject.SetActive(b);
    //}

    [Server]
    public void SetActive(bool b) {
        gameObject.SetActive(b);
        RpcClientActive(b);
    }

    [ClientRpc]
    private void RpcClientActive(bool b) {
        gameObject.SetActive(b);
    }

}

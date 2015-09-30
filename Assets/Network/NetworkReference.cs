using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkReference : NetworkBehaviour {

    public void disconnect() {
        if (isServer) {
            NetworkManager.singleton.StopHost();
        } else {
            NetworkManager.singleton.StopClient();
        }
    }

    public void start() {
        NetworkManager.singleton.StartHost();
    }

    public void join() {
        NetworkManager.singleton.StartClient();
    }
}

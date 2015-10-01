using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkReference : NetworkBehaviour {

    public void disconnect() {
        // SHUT THEM ALL DOWN!!!
        NetworkManager.singleton.StopClient();
        NetworkManager.singleton.StopHost();
    }

    public void start() {
        Debug.Log("Starting Host.");
        NetworkManager.singleton.StartHost();
    }

    public void join() {
        Debug.Log("Starting Client.");
        NetworkManager.singleton.StartClient();
    }

}

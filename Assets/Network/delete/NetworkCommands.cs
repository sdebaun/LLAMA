using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkCommands : NetworkBehaviour {

    public GameNetwork network;

    void Start() {
        DontDestroyOnLoad(this.gameObject);
    }

    public void disconnect() {
        if (isServer) {
            Debug.Log("Stopping Host.");
            NetworkManager.singleton.StopHost();
        }
        if (isClient) {
            Debug.Log("Stopping Client.");
            NetworkManager.singleton.StopClient();
        }
    }

    public void start() {
        Debug.Log("Starting Host.");
        NetworkManager.singleton.StartHost();
        DontDestroyOnLoad(this);
    }

    public void join() {
        Debug.Log("Starting Client.");
        NetworkManager.singleton.StartClient();
    }

}

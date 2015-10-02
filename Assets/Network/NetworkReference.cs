using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkReference : NetworkBehaviour {

    public void disconnect() {
        // SHUT THEM ALL DOWN!!!
        NetworkManager.singleton.StopClient();
        NetworkManager.singleton.StopHost();
    }

    public void startHost() {
        Debug.Log("Starting Host.");
        NetworkManager.singleton.StartHost();
    }

    public void startClient() {
        Debug.Log("Starting Client, connecting to " + NetworkManager.singleton.networkAddress);
        NetworkManager.singleton.StartClient();
    }

    public void setNetworkAddress(string s) {
        Debug.Log("Setting network address to " + s);
        NetworkManager.singleton.networkAddress = s;
    }

}

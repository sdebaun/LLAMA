using UnityEngine;
using UnityEngine.Networking;
using System.Collections;


public class GameNetwork : NetworkManager {

    //public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId) {
    //    GameObject player = (GameObject)Instantiate(playerPrefab);
    //    NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    //}

    public void Start() {
        Application.LoadLevel(offlineScene);
    }
}

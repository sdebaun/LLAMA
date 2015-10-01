using UnityEngine;
using UnityEngine.Networking;
using System.Collections;


public class GameNetwork : NetworkManager {

    public void Start() {
        Application.LoadLevel(offlineScene);
    }
}

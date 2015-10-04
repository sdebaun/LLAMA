using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ColonyCenter : NetworkBehaviour {

    void OnDestroy() {
        GameObject.Find("NetworkReference").GetComponent<NetworkReference>().disconnect(); // rocks fall, everyone dies
    }

}

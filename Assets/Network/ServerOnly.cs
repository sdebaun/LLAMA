using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ServerOnly : MonoBehaviour {

	void Start () {
        Debug.Log("Server is active " + NetworkServer.active);
	    gameObject.SetActive(NetworkServer.active);
	}
	
}

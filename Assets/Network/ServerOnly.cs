using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ServerOnly : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Server is active " + NetworkServer.active);
	    gameObject.SetActive(NetworkServer.active);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

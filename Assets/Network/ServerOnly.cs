using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ServerOnly : MonoBehaviour {

	void Start () {
	    gameObject.SetActive(NetworkServer.active);
	}
	
}

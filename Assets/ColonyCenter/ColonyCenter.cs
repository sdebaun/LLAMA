using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ColonyCenter : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy() {
        Application.LoadLevel("Menu"); // rocks fall, everyone dies
    }

}

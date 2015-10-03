using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ColonyCenter : NetworkBehaviour {

    public Text ccHealth;

    private Damageable damageable;

	// Use this for initialization
	void Start () {
        damageable = GetComponent<Damageable>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isClient) { ccHealth.text = "" + (int)damageable.currentHealth; }
    }

    void OnDestroy() {
        Application.LoadLevel("Menu"); // rocks fall, everyone dies
    }

}

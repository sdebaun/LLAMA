using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ColonyCenter : NetworkBehaviour {

    public Text ccHealth;

    private Damageable damageable;

    // public so it is exposed in the inspector
    public GamePhase gamePhase;

	// Use this for initialization
	void Start () {
        damageable = GetComponent<Damageable>();
        gamePhase = GameObject.Find("GameManager").GetComponent<GamePhase>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isClient) { ccHealth.text = "" + (int)damageable.currentHealth; }
    }

    void OnDestroy() {
        gamePhase.EndGame();
    }

}

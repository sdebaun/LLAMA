using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ColonyCenter : NetworkBehaviour {

    public Damageable damageable;
    public GameController game;

	// Use this for initialization
	void Start () {
        if (isServer) damageable.killListeners += () => game.End();
	}
	
}

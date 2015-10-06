using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class EndGameOnDestroy : NetworkBehaviour {

    public GameController game;
    public Damageable damageable;

    // Use this for initialization
    void Start() {
        if (isServer) damageable.killListeners += () => game.End();
    }

}

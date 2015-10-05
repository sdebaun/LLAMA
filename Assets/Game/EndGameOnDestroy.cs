using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class EndGameOnDestroy : NetworkBehaviour {

    public GameController game;

    void OnDestroy() {
        game.End();
    }

}

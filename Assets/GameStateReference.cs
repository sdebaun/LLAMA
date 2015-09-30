using UnityEngine;
using System.Collections;

public class GameStateReference : MonoBehaviour {

    private GameObject gameState;

	// Use this for initialization
	void Start () {
        gameState = GameObject.Find("GameManager");
	}
	
	public void Rebuild() {
        gameState.GetComponent<BuildWorld>().CmdRebuild();
    }
}

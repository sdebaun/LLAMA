using UnityEngine;
using System.Collections;

public class GameStateReference : MonoBehaviour {

    private GameObject gameState;

	void Start () {
        gameState = GameObject.Find("GameManager");
	}
	
	public void Rebuild() {
        gameState.GetComponent<BuildWorld>().CmdRebuild();
    }

    public void StartGame() {
        gameState.GetComponent<GamePhase>().CmdSwitchTo("day");
    }
}

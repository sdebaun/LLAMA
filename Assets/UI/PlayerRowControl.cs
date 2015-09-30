using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerRowControl : MonoBehaviour {

    public Text nameLabel;

    private PlayerModel player;

    public void setPlayer(PlayerModel p) {
        player = p;
        nameLabel.color = player.color;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

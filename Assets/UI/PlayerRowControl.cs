using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerRowControl : MonoBehaviour {

    public Text nameLabel;

    private PlayerModel player;

    public void setPlayer(PlayerModel p) {
        player = p;
        nameLabel.color = player.gameObject.GetComponent<RandomColor>().color;
    }

    public bool isForPlayer(PlayerModel p) {
        return p == player;
    }
}

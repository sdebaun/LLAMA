using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// used in the world ui
public class PlayerRowControl : MonoBehaviour {

    public Text nameLabel;
    public List<Image> coloredImages = new List<Image>();

    public bool textColor = true;

    private PlayerModel player;
    private Color color;

    public void setPlayer(PlayerModel p) {
        player = p;
        color = player.gameObject.GetComponent<RandomColor>().color;
        if (textColor) nameLabel.color = color;
        foreach (Image i in coloredImages) { i.color = color; }
    }

    public bool isForPlayer(PlayerModel p) {
        return p == player;
    }
}

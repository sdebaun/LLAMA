using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System.Collections.Generic;

// used by the player prefab
public class RandomColor : NetworkBehaviour {

    public static Color[] allowedColors = { Color.cyan, Color.red, Color.yellow, Color.magenta };
    public static List<Color> availableColors = new List<Color>(allowedColors);

    public delegate void ChangeListener(Color c);
    public event ChangeListener changeListeners;

    [SyncVar(hook = "OnChange")]
    public Color color;
    void OnChange(Color c) {
        if (changeListeners != null) changeListeners(c);
    }

    public override void OnStartServer() {
        color = newRandomColor();
    }

    public override void OnStartClient() {
        OnChange(color);
    }

    [Server]
    private Color newRandomColor() {
        Color c = availableColors[Random.Range(0, availableColors.Count)];
        availableColors.Remove(c);
        return c;
    }

    public override void OnNetworkDestroy() {
        if (isServer) availableColors.Add(color);
    }

}

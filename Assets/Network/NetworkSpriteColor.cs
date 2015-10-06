using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class NetworkSpriteColor : NetworkBehaviour {

    public List<SpriteRenderer> sprites = new List<SpriteRenderer>();

    [SyncVar(hook = "OnChange")]
    public Color color;
    private void OnChange(Color c) {
        foreach (SpriteRenderer sprite in sprites) { sprite.color = c; }
    }

    void Start() {
        OnChange(color);
    }
}

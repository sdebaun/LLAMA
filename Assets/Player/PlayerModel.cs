using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerModel : NetworkBehaviour {

    [SyncVar]
    public Color color;

    private PlayerListControl players;

    public override void OnStartAuthority() {
        Debug.Log("Starting PlayerModel on Authority");
        color = newRandomColor();
    }

    private Color newRandomColor() {
        float[] c = { Random.Range(0.3f, 0.5f), Random.Range(0.3f, 0.5f), Random.Range(0.3f, 0.5f) };
        c[Random.Range(0, 3)] += Random.Range(0.4f, 0.5f);
        return new Color(c[0],c[1],c[2]);
    }

    // Use this for initialization
    void Start () {
        Debug.Log("Starting PlayerModel");
        // gotta be a better way to do this
        GameObject go = GameObject.Find("PlayerList");
        players = go.GetComponent<PlayerListControl>();
        players.Add(this);
    }

    // Update is called once per frame
    void Update () {
	
	}

    public override void OnNetworkDestroy() {
        players.Remove(this);
    }

}

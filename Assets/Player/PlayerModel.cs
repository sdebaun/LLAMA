using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerModel : NetworkBehaviour {

    [SyncVar]
    public Color color;

    private PlayerListControl players;

    public override void OnStartAuthority() {
        Debug.Log("Starting PlayerModel on Authority");
        color = new Color(Random.Range(0.7f, 1f), Random.Range(0.7f, 1f), Random.Range(0.7f, 1f));
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
}

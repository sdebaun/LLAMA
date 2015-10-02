using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ServerDriven : NetworkBehaviour {

    [SyncVar(hook = "OnActive")]
    public bool serverActive;
    public void OnActive(bool b) {
        Debug.Log("OnActive sync hook");
        gameObject.SetActive(b);
    }

    [SyncVar(hook = "OnSpriteColor")]
    public Color serverSpriteColor;
    public void OnSpriteColor(Color c) {
        Debug.Log("OnSpriteColor sync hook");
        gameObject.GetComponent<SpriteRenderer>().color = c;
    }

    public override void OnStartClient() {
        Debug.Log("OnStartClient " + serverActive + serverSpriteColor);
        gameObject.SetActive(serverActive);
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        if (sprite) { sprite.color = serverSpriteColor; }
    }

    public void SetActive(bool b) {
        gameObject.SetActive(b);
        serverActive = b;
    }

    public void SetSpriteColor(Color c) {
        //gameObject.GetComponent<SpriteRenderer>().color = c;
        serverSpriteColor = c;
    }

}

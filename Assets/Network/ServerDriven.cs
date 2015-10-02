using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ServerDriven : NetworkBehaviour {

    [SyncVar(hook = "OnActive")]
    public bool serverActive = true;
    public void OnActive(bool b) {
        gameObject.SetActive(b);
    }

    [SyncVar(hook = "OnSpriteColor")]
    public Color serverSpriteColor;
    public void OnSpriteColor(Color c) {
        gameObject.GetComponent<SpriteRenderer>().color = c;
    }

    [SyncVar(hook = "OnMeshColor")]
    public Color serverMeshColor;
    public void OnMeshColor(Color c) {
        //gameObject.GetComponent<MeshRenderer>().material.color = c;
        MeshRenderer[] meshes = GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer m in meshes) {
            Debug.Log("Setting color on mesh");
            m.material.color = c;
        }
    }

    public override void OnStartClient() {
        OnActive(serverActive);
        if (gameObject.GetComponent<SpriteRenderer>() != null) { OnSpriteColor(serverSpriteColor); }
        if (gameObject.GetComponentsInChildren<MeshRenderer>().Length > 0) { OnMeshColor(serverMeshColor); }
    }

    public void SetActive(bool b) {
        gameObject.SetActive(b);
        serverActive = b;
    }

    public void SetMeshColor(Color c) {
        serverMeshColor = c;
    }

    public void SetSpriteColor(Color c) {
        serverSpriteColor = c;
    }

}

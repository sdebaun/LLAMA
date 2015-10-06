using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class NetworkMeshColor : NetworkBehaviour {

    public List<MeshRenderer> meshes = new List<MeshRenderer>();

    [SyncVar(hook = "OnChange")]
    public Color color;
    private void OnChange(Color c) {
        foreach (MeshRenderer mesh in meshes) { mesh.material.color = c; }
    }

    void Start() {
        OnChange(color);
    }
}

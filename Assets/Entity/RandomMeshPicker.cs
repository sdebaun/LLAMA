using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class RandomMeshPicker : MonoBehaviour {

    public Mesh[] prefabs;
    public MeshFilter meshFilter;

    void Start() {
        meshFilter.mesh = prefabs[Random.Range(0, prefabs.Length)];
        print("Set mesh filter to " + meshFilter.mesh);
    }

}

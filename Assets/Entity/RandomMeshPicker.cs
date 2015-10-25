using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// used in trees, rocks, etc
public class RandomMeshPicker : MonoBehaviour {

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    public Mesh[] prefabs;
    public MeshFilter meshFilter;

    void Start() {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = prefabs[Random.Range(0, prefabs.Length)];
        float s = Random.Range(.8f, 1.2f);
        Vector3 v = gameObject.transform.localScale;
        gameObject.transform.localScale = new Vector3(v.x*s,v.y*s,v.z*s);
    }

}

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class BuildWorld : MonoBehaviour {

    public string prefabFolderResourcePath;
    public string generationNodeTag;
    public string placementTag;

    private GameObject[] prefabs;

	// Use this for initialization
	void Start () {
        prefabs = Resources.LoadAll<GameObject>(prefabFolderResourcePath);
        Run();
	}
	
    void Clear() {
        GameObject[] placements = GameObject.FindGameObjectsWithTag(placementTag);
        foreach (GameObject p in placements) {
            Destroy(p);
        }
    }

    void Run() {
        GameObject[] nodes = GameObject.FindGameObjectsWithTag(generationNodeTag);
        foreach (GameObject n in nodes) {
            GameObject newPlaced = Instantiate<GameObject>(prefabs[Random.Range(0, prefabs.Length)]);
            NetworkServer.Spawn(newPlaced);
            newPlaced.transform.SetParent(n.transform,false);
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}

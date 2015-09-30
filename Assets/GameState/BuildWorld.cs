using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

//public class BuildWorld : MonoBehaviour {
public class BuildWorld : NetworkBehaviour {

    public string prefabFolderResourcePath;
    public string generationNodeTag;
    public string placementTag;

    private GameObject[] prefabs;

    public override void OnStartAuthority() {
        Debug.Log("Build Component starting on AUTHORITY from " + gameObject.name);
        prefabs = Resources.LoadAll<GameObject>(prefabFolderResourcePath);
        Build();
    }

    public override void OnStartClient() {
        Debug.Log("Build Component starting on CLIENT from " + gameObject.name);
    }

    // Use this for initialization
    void Start () {
        //Debug.Log("Build Component starting from " + gameObject.name);
        //prefabs = Resources.LoadAll<GameObject>(prefabFolderResourcePath);
        //Build();
	}
	
    [Command]
    public void CmdRebuild () {
        Clear();
        Build();
    }

    void Clear() {
        GameObject[] placements = GameObject.FindGameObjectsWithTag(placementTag);
        foreach (GameObject p in placements) {
            Destroy(p);
        }
    }

    void Build() {
        GameObject[] nodes = GameObject.FindGameObjectsWithTag(generationNodeTag);
        Debug.Log("Building new world.");
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

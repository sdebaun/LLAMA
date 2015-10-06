using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class BuildWorld : NetworkBehaviour {

    public string prefabFolderResourcePath;
    public string generationNodeTag;
    public string placementTag;
    public GameObject creepSpawnPrefab;
    public int creepSpawnCount = 3;
    public string creepSpawnTag;
    public string creepTag;
    public float spawnPlacementRadius = 22f;

    private GameObject[] prefabs;

    public override void OnStartAuthority() {
        Debug.Log("Build Component starting on AUTHORITY from " + gameObject.name);
        prefabs = Resources.LoadAll<GameObject>(prefabFolderResourcePath);
        Build();
    }

    public override void OnStartClient() {
        Debug.Log("Build Component starting on CLIENT from " + gameObject.name);
    }

    [Command]
    public void CmdRebuild () {
        Clear();
        Build();
    }

    void Clear() {
        string[] tagsToDestroy = { placementTag, creepSpawnTag, creepTag };
        foreach (string tag in tagsToDestroy) { DestroyAllWithTag(tag); }
    }

    void DestroyAllWithTag(string tag) {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag(tag)) { Destroy(g); }
    }

    public void Build() {
        GameObject[] nodes = GameObject.FindGameObjectsWithTag(generationNodeTag);
        Debug.Log("Building new world.");
        foreach (GameObject n in nodes) {
            GameObject newPlaced = Instantiate<GameObject>(prefabs[Random.Range(0, prefabs.Length)]);
            NetworkServer.Spawn(newPlaced);
            newPlaced.transform.SetParent(n.transform, false);
            Vector3 randomRotation = UnityEngine.Random.onUnitSphere;
            randomRotation.y = 0;
            newPlaced.transform.rotation = Quaternion.LookRotation(randomRotation);
        }
        for (int i=0;i<creepSpawnCount;i++) {
            Vector2 randomPerimeterPosition = UnityEngine.Random.insideUnitCircle.normalized * spawnPlacementRadius;
            GameObject newSpawn = Instantiate<GameObject>(creepSpawnPrefab);
            NetworkServer.Spawn(newSpawn);
            newSpawn.transform.position = new Vector3(randomPerimeterPosition.x, 0, randomPerimeterPosition.y);
            newSpawn.GetComponent<CreepSpawn>().SetSpawningGhost(2f);
        }
    }

}

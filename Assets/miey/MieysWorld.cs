using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MieysWorld : NetworkBehaviour {

    public CreepSpawn creepSpawn;

    public override void OnStartAuthority() {
        Debug.Log("Build Component starting on AUTHORITY from " + gameObject.name);
        // prefabs = Resources.LoadAll<GameObject>(prefabFolderResourcePath);
        creepSpawn.StartGhost(1f);
    }

    public override void OnStartClient() {
        Debug.Log("Build Component starting on CLIENT from " + gameObject.name);
    }
}

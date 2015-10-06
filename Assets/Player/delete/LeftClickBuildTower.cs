using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class LeftClickBuildTower : NetworkBehaviour {

    public GameObject buildPrefab;

	void Update () {
        if (isLocalPlayer) {
            if (Input.GetMouseButtonUp(0)) {
                Vector3 mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                CmdBuildAt(new Vector3(mPos.x, 0f, mPos.z));
            }
        }
    }

    [Command]
    public void CmdBuildAt(Vector3 p) {
        SpawnNewTower(p);
    }

    public GameObject SpawnNewTower(Vector3 p) {
        GameObject c = Instantiate(buildPrefab, p, Quaternion.identity) as GameObject;
        NetworkServer.Spawn(c);
        return c;
    }

}

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Builder : NetworkBehaviour {

    public enum Type { Tower, Extract };

    public KeyCode toggleKey;

    public GameObject buildPrefab;
    public GameObject ghostPrefab;

    public bool isActive;

    public GameObject currentGhost;

    [SyncVar(hook = "OnChange")]
    public int allowedBuilds;
    private void OnChange(int i) {
        allowedBuilds = i;
        if ((allowedBuilds <= 0) && isActive) Off();
    }

    [Client]
    public void On() {
        if (allowedBuilds > 0) {
            isActive = true;
            currentGhost = Instantiate(ghostPrefab) as GameObject;
        }
    }

    [Client]
    public void Off() {
        isActive = false;
        Destroy(currentGhost);
    }

    [Client]
    public bool CanBuild() {
        return isActive && (allowedBuilds>0) && ghostPrefab.GetComponent<BuildableGhost>().isValid;
    }

    [Server]
    public void AddBuilds(int i) { allowedBuilds += i; }

    //[Client]
    //public void Build() {
    //    CmdSpawn(currentGhost.transform.position);
    //}

    //[Command]
    //public void CmdSpawn(Vector3 position) {
    //    GameObject g = Instantiate(buildPrefab, position, Quaternion.identity) as GameObject;
    //    NetworkServer.Spawn(g);
    //    allowedBuilds--;
    //}

}

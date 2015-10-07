using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class BuildMode : NetworkBehaviour {

    public List<Builder> builders;
    public Builder currentBuilder;

    void Update() {
        if (isLocalPlayer) {
            foreach (Builder b in builders) {
                if (Input.GetKeyDown(b.toggleKey)) Toggle(b);
            }
        }
    }

    [Client]
    public void Toggle(Builder b) {
        if (currentBuilder == b) {
            if (currentBuilder) currentBuilder.Off();
            currentBuilder = null;
        } else {
            if (currentBuilder) currentBuilder.Off();
            if (b) b.On();
            currentBuilder = b;
        }
    }

    [Client]
    public bool CanBuild() { return (currentBuilder!=null) && currentBuilder.CanBuild(); }

    [Client]
    public void Build() {
        CmdSpawn(builders.IndexOf(currentBuilder), currentBuilder.currentGhost.transform.position);
    }

    [Command]
    public void CmdSpawn(int bIndex, Vector3 position) {
        GameObject g = Instantiate(builders[bIndex].buildPrefab, position, Quaternion.identity) as GameObject;
        NetworkServer.Spawn(g);
        builders[bIndex].allowedBuilds--;
    }


}

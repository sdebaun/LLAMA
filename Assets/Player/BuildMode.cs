using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class BuildMode : NetworkBehaviour {

    public List<Builder> builders;
    public Builder currentBuilder;
    public NetworkQuantity colonyResources;

    void Start() {
        if (isServer) {
            colonyResources = GameObject.Find("ColonyCenter").GetComponent<ColonyCenterController>().resources;
        }
    }
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
            if (currentBuilder) currentBuilder.Next();
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
        CmdBuild(builders.IndexOf(currentBuilder), currentBuilder.currentPrefabIndex, currentBuilder.currentGhost.transform.position);
    }

    [Command]
    public void CmdBuild(int bIndex, int pIndex, Vector3 position) {
        //ExtractController.Create(builders[bIndex].buildPrefabs[pIndex], position);
        //Vector3 startPos = new Vector3(position.x, -10, position.z);
        //GameObject g = Instantiate(builders[bIndex].buildPrefabs[pIndex], startPos, Quaternion.identity) as GameObject;
        GameObject g = Instantiate(builders[bIndex].buildPrefabs[pIndex], position, Quaternion.identity) as GameObject;
        NetworkServer.Spawn(g);
        //g.transform.position = position; // this horrible hack to force triggers
        builders[bIndex].allowedBuilds--;
        colonyResources.amount-=builders[bIndex].resourceCost;
    }


}

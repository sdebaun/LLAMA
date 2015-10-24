using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System.Collections.Generic;

// used in player prefab
public class BuildMode : NetworkBehaviour {

    public List<Builder> builders;
    public Builder currentBuilder;
    public NetworkQuantity colonyResources;
    public AudioSource buildSound;

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
        buildSound.Play();
    }

    [Command]
    public void CmdBuild(int bIndex, int pIndex, Vector3 position) {
        GameObject g = Instantiate(builders[bIndex].buildPrefabs[pIndex], position, Quaternion.identity) as GameObject;
        NetworkServer.Spawn(g);
        builders[bIndex].allowedBuilds--;
        colonyResources.amount-=builders[bIndex].resourceCost;
    }


}

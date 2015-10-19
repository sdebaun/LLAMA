using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CollectionPhase : Phase {

    public NetworkQuantity colonyResources;
    public WorldLightController worldLight;

    private int extractsToGenerate;
    public void ExtractorDone() {
        extractsToGenerate--;
        if (extractsToGenerate == 0) Next();
        print("extracts remaining ungenerated " + extractsToGenerate);
    }

    [Server]
    public override void OnBegin() {
        worldLight.RotateToDawn(3f);
        foreach (ExtractController e in ExtractController.items) {
            colonyResources.amount += e.quantity.amount;
            e.quantity.amount = 0;
        }
        Next(3f);
    }

    [Server]
    public override void OnEnd() {
        //GameObject.Find("Sun").GetComponent<Sun>().enabled = false;
    }

}

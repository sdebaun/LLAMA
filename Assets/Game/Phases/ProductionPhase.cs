﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ProductionPhase : Phase {

    private int extractsToGenerate;
    public void ExtractorDone() {
        extractsToGenerate--;
        if (extractsToGenerate == 0) Next();
        print("extracts remaining ungenerated " + extractsToGenerate);
    }

    [Server]
    public override void OnBegin() {
        extractsToGenerate = ExtractController.items.Count;
        foreach (ExtractController e in ExtractController.items) {
            print("Starting production for " + e.name);
            e.StartGenerating(ExtractorDone);
        }
        if (extractsToGenerate == 0) Next();
    }

    [Server]
    public override void OnEnd() {
        //GameObject.Find("Sun").GetComponent<Sun>().enabled = false;
    }

}

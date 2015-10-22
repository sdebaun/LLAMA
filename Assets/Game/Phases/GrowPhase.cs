using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GrowPhase : Phase {

    public int winSize = 3;
    public int growthCostPerSize = 10;

    public NetworkQuantity colonyResources;
    public NetworkQuantity resourcesConsumed;
    public NetworkQuantity growthThreshold;
    public NetworkQuantity colonySize;
    public EventRepeater repeater;

    [Server]
    public override void OnBegin() {
        if (colonyResources.amount > 0) repeater.Begin(Grow, 0.5f, 0.5f);
        else Next(3f);
    }

    [Server]
    public void Grow() {
        colonyResources.amount--;
        resourcesConsumed.amount++;
        if (resourcesConsumed.amount > growthThreshold.amount) {
            resourcesConsumed.amount -= growthThreshold.amount;
            colonySize.amount += 1;
            growthThreshold.amount = colonySize.amount * growthCostPerSize;
            if (colonySize.amount >= winSize) {
                repeater.End();
                game.Win();
            }
        }
        if (colonyResources.amount == 0) {
            repeater.End();
            Next(3f);
        }
    }

}

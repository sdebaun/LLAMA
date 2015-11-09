using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using Pathfinding;

public enum EnvironmentState { Night, Day };

public interface IEnvironmentController {
    void TransitionTo(EnvironmentState state);
}

public class EnvironmentController : NetworkBehaviour, IEnvironmentController {

    public INetworkToggle dayNightSounds;
    public IWorldLightController worldLight;

    public void TransitionTo(EnvironmentState state) {
        if (state==EnvironmentState.Night) {
            dayNightSounds.Set(false);
            worldLight.RotateToMidnight(3f);
        }
    }
}

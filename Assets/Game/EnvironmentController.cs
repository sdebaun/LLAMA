using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using Pathfinding;

public enum EnvironmentState { Night, Day };

public interface IEnvironmentController {
    void TransitionTo(EnvironmentState state);
}

public delegate Component ChildComponentFinderDelegate(System.Type t);

public class EnvironmentController : NetworkBehaviour, IEnvironmentController {

    public INetworkToggle dayNightSounds;
    public IWorldLightController worldLight;

    public ChildComponentFinderDelegate getComponent;

    public void Start() {
        if (getComponent==null) { getComponent = GetComponentInChildren; }
        dayNightSounds = getComponent(typeof(NetworkToggle)) as NetworkToggle;
        worldLight = getComponent(typeof(WorldLightController)) as WorldLightController;
    }

    public void TransitionTo(EnvironmentState state) {
        if (state==EnvironmentState.Night) {
            dayNightSounds.Set(false);
            worldLight.RotateToMidnight(3f);
        }
    }
}

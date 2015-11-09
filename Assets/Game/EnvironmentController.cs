using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using Pathfinding;

public enum EnvironmentState { Night };


public interface IEnvironmentController {
    void TransitionTo(EnvironmentState state);
}

// used by gameobject with same name in World scene, child to Game
public class EnvironmentController : NetworkBehaviour, IEnvironmentController {

    public void TransitionTo(EnvironmentState state) { }
}

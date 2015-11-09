using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using Pathfinding;

// used by gameobject with same name in World scene, child to Game
public class EnvironmentController : NetworkBehaviour {

    public enum State { Night };

    public void TransitionTo(State state) { }
}

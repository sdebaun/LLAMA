using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Assertions;

/*
Controllers inherit from this and specify their baseInstanceName
*/
public class ControllerBehaviour : BaseBehaviour {
    public static string baseInstanceName = "ControlledObject";
}

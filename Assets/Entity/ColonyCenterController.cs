using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// used in cc in world scene
public class ColonyCenterController : NetworkBehaviour {

    public NetworkQuantity resources;
    public NetworkQuantity consumed;
    public NetworkQuantity size;

}

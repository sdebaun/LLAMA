using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Linq;

// used in "Game" object in world scene
public class XenoController : NetworkBehaviour {

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    public string campTag = "Camp";

    public List<CampController> FindAllCamps() {
        return GameObject.FindGameObjectsWithTag(campTag).Select<GameObject, CampController>(item => item.GetComponent<CampController>()).ToList();
    }
}

using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Linq;

public class XenoController : NetworkBehaviour {

    public string campTag = "Camp";

    public List<CampController> FindAllCamps() {
        return GameObject.FindGameObjectsWithTag(campTag).Select<GameObject, CampController>(item => item.GetComponent<CampController>()).ToList();
    }
}

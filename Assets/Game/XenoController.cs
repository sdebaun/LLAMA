using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Linq;

public interface IXenoController {
    void StartSpawning(int count, float duration);
}

// used in "Game" object in world scene
public class XenoController : NetworkBehaviour, IXenoController {

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    public string campTag = "Camp";

    public List<CampController> FindAllCamps() {
        Debug.LogError("DEPRECATED, WHY ARE YOU CALLING THIS");
        return GameObject.FindGameObjectsWithTag(campTag).Select<GameObject, CampController>(item => item.GetComponent<CampController>()).ToList();
    }

    public void StartSpawning(int count, float duration) {
        print("StartSpawning " + count + " " + duration);
    }

}

using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

/*
used in: colonycenter
*/
public class HouseBuilder : NetworkBehaviour {

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    public List<GameObject> houses = new List<GameObject>();

    public void OnSize(int newSize) {
        for (int i=0;i<newSize;i++) {
            houses[i].SetActive(true);
        }
    }
}

using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

/*
Hooks up to events that 
*/
public class HouseBuilder : NetworkBehaviour {

    public List<GameObject> houses = new List<GameObject>();

    public void OnSize(int newSize) {
        for (int i=0;i<newSize;i++) {
            houses[i].SetActive(true);
        }
    }
}

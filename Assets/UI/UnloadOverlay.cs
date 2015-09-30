using UnityEngine;
using System.Collections;

public class UnloadOverlay : MonoBehaviour {

    public string unloadScene;

    public void trigger() {
        Debug.Log(unloadScene);
        Application.UnloadLevel(unloadScene);
    }
}
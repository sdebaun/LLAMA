using UnityEngine;
using System.Collections;

public class UnloadOverlay : MonoBehaviour {

    public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    public string unloadScene;

    public void trigger() {
        Debug.Log(unloadScene);
        Application.UnloadLevel(unloadScene);
    }
}
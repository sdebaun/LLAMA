using UnityEngine;
using System.Collections;

public class LoadOverlayAuto : MonoBehaviour {

    public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    public string overlayScene;

	void Start () {
        Debug.Log(overlayScene);
        Application.LoadLevelAdditive(overlayScene);
	}
}

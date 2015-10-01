using UnityEngine;
using System.Collections;

public class LoadOverlayAuto : MonoBehaviour {

    public string overlayScene;

	void Start () {
        Debug.Log(overlayScene);
        Application.LoadLevelAdditive(overlayScene);
	}
}

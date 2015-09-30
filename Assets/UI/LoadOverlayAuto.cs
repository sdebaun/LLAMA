using UnityEngine;
using System.Collections;

public class LoadOverlayAuto : MonoBehaviour {

    public string overlayScene;

	// Use this for initialization
	void Start () {
        Debug.Log(overlayScene);
        Application.LoadLevelAdditive(overlayScene);
	}
	
	// Update is called once per frame
	void Update () {
	}
}

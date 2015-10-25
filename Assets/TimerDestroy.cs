using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// used in creephitblood
public class TimerDestroy : NetworkBehaviour {

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    public float seconds = 30;

	void Start () {
        Destroy(gameObject, seconds);
	}
}

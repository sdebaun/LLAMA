using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TimerDestroy : NetworkBehaviour {

    public float seconds = 30;

	void Start () {
        Destroy(gameObject, seconds);
	}
}

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Sun : NetworkBehaviour {

    public bool isRisen = false; // a risen sun moves across the sky until the rotation is >180 or <0
    public float daySeconds = 3;
    public float curTime = 0;

    private Light theSun;
    private float theAngle;

    void Start () {
        theSun = GetComponent<Light>();
    }

	[ClientRpc]
    public void RpcRise(float secondsToSet) {
        daySeconds = secondsToSet;
        isRisen = true;
        theSun.enabled = true;
    }

    private void SetSunAngle(float angle) {
		theSun.transform.rotation = Quaternion.Euler (angle, 90, 0);
	}

	// Update is called once per frame
	void Update () {
	    if (isClient && isRisen) {
            // Set the rotation mapping the range 0-180 degrees X rotation to the range 0-daySeconds seconds
            theAngle = 180 * (daySeconds - curTime) / daySeconds;
			SetSunAngle(theAngle);
            curTime += Time.deltaTime;
            if (curTime > daySeconds) { // Sun has set
                curTime = 0;
                isRisen = false;
				SetSunAngle(270);
                theSun.enabled = false;
            }
        }
	}
}

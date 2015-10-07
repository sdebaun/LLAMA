using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {

    public bool isRisen = false; // a risen sun moves across the sky until the rotation is >180 or <0
    public float daySeconds = 3;
    public float curTime = 0;

    private Light theSun;
    private float theAngle;

    void Start () {
        theSun = GetComponent<Light>();
    }

    public void Rise(float secondsToSet) {
        daySeconds = secondsToSet;
        isRisen = true;
    }

	// Update is called once per frame
	void Update () {
	    if (isRisen) {
            // Set the rotation mapping the range 0-180 degrees X rotation to the range 0-daySeconds seconds
            theAngle = 180 * (daySeconds - curTime) / daySeconds;
            theSun.transform.rotation = Quaternion.Euler(theAngle, 90, 0);
            curTime += Time.deltaTime;
            if (curTime > daySeconds) { // Sun has set
                curTime = 0;
                isRisen = false;
            }
        }
	}
}

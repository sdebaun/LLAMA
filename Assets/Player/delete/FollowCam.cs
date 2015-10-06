using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
    public float scrollSpeed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform) {
            Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, transform.position.z);

            //Vector3 point = Camera.main.WorldToViewportPoint(transform.position);
            //Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            //Vector3 destination = transform.position + delta;
            //transform.position = Vector3.Lerp(transform.position, destination, scrollSpeed);
            ////transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
	
	}
}

using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
    public float scrollSpeed = 1f;

	void Update () {
        Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, transform.position.z);
	}
}

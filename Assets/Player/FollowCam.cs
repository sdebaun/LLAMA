﻿using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	void Update () {
        Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, transform.position.z);
	}
}

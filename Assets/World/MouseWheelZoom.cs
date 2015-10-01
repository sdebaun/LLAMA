using UnityEngine;
using System.Collections;

public class MouseWheelZoom : MonoBehaviour {

	public float maxOrthographicSize = 6;
	public float minOrthographicSize = 1;
	public float zoomInFactor = 0.9f;
	public float zoomOutFactor = 1.1f;

	void Update () {
		float mouseScroll = Input.GetAxis ("Mouse ScrollWheel");
		if (mouseScroll < 0) {
			Camera.main.orthographicSize = Mathf.Min (Camera.main.orthographicSize * zoomOutFactor, maxOrthographicSize);
		} else if (mouseScroll > 0) {
			Camera.main.orthographicSize = Mathf.Max (Camera.main.orthographicSize * zoomInFactor, minOrthographicSize);
		}
	}
}

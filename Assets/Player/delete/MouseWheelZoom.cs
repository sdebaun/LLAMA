using UnityEngine;
using System.Collections;

public class MouseWheelZoom : MonoBehaviour {

    public float zoomInFactor = 0.9f;
    public float zoomOutFactor = 1.1f;

    public float minOrthographicSize = 1;
    public float maxOrthographicSize = 6;

    public float minPerspectiveHeight = 4;
    public float maxPerspectiveHeight = 8;

	void Update () {
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        if (mouseScroll != 0) {
            if (Camera.main.orthographic) {
                Camera.main.orthographicSize = (mouseScroll < 0) ?
                    Mathf.Min(Camera.main.orthographicSize * zoomOutFactor, maxOrthographicSize) :
                    Mathf.Max(Camera.main.orthographicSize * zoomInFactor, minOrthographicSize);
            } else { //its perspective
                Vector3 p = Camera.main.transform.position;
                float newY = (mouseScroll < 0) ?
                    Mathf.Min(p.y * zoomOutFactor, maxPerspectiveHeight) :
                    Mathf.Max(p.y * zoomInFactor, minPerspectiveHeight);
                //Debug.Log("New Y " + newY);
                Camera.main.transform.position = new Vector3(p.x, newY, p.z);
            }
        }
    }
}

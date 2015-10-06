using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {

    private Plane hitPlane;

    void Start() {
        hitPlane = new Plane(Vector3.up,Vector3.zero);
    }

	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        hitPlane.Raycast(ray, out distance);
        transform.position = ray.GetPoint(distance);
        // orthographic if we ever care
        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //worldPosition.y = 0;
        //Debug.Log("New mouse position screen/world: " + Input.mousePosition + " " + worldPosition);
        //transform.position = worldPosition;
    }
}

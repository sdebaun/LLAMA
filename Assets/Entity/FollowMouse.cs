using UnityEngine;
using System.Collections;

// used by: ghosts
public class FollowMouse : MonoBehaviour {

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

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

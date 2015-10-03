using UnityEngine;
using System.Collections;

public class AttackEffect : MonoBehaviour {

    public GameObject source;
    public GameObject target;

    public LineRenderer pewpew;

    // Use this for initialization
    void Start () {
        pewpew.SetWidth(0.2f, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
        if (target) {
            pewpew.SetPosition(0, source.transform.position);
            pewpew.SetPosition(1, target.transform.position);
        }
    }

    public void switchTo(GameObject g) {
        target = g;
        pewpew.enabled = true;
    }

    public void disable() {
        target = null;
        pewpew.enabled = false;
    }
}

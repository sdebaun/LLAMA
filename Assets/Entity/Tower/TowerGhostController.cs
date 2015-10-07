using UnityEngine;
using System.Collections;

public class TowerGhostController : MonoBehaviour {

    public SpriteRenderer activationCircle;

    private int currentCollisions = 0;
    public bool isValid = true;
    private Color valid, invalid;

    void Start () {
        valid = new Color(0, 1f, 0, 0.5f);
        invalid = new Color(1f, 0, 0, 0.5f);
        isValid = true;
        activationCircle.color = valid;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag != "Terrain") return;
        currentCollisions++;
        //print("Started colliding with " + other + ", collisions:" + currentCollisions);
        activationCircle.color = invalid;
        isValid = false;
    }

    void OnTriggerExit(Collider other) {
        if (other.tag != "Terrain")  return;
        currentCollisions--;
        //print("Stopped colliding with " + other + ", collisions:" + currentCollisions);
        if (currentCollisions == 0) {
            activationCircle.color = valid;
            isValid = true;
        }
        
    }

}

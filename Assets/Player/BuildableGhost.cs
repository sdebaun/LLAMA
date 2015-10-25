using UnityEngine;
using System.Collections;

// used in ghosts: tower, extract
public class BuildableGhost : MonoBehaviour {

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    public SpriteRenderer activationCircle;

    private int currentCollisions = 0;
    public bool isValid = true;
    private static Color valid = new Color(0, 1f, 0, 0.5f);
    private static Color invalid = new Color(1f, 0f, 0, 0.5f);

    void Start () {
        isValid = true;
        activationCircle.color = valid;
    }

    public void Entered(GameObject g, int p) {
        currentCollisions++;
        activationCircle.color = invalid;
        isValid = false;
    }

    public void Exited(GameObject g, int p) {
        currentCollisions--;
        if (currentCollisions == 0) {
            activationCircle.color = valid;
            isValid = true;
        }
    }

}

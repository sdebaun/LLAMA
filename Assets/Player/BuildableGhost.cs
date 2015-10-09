using UnityEngine;
using System.Collections;

public class BuildableGhost : MonoBehaviour {

    public SpriteRenderer activationCircle;
    public GameObject trigger;

    private int currentCollisions = 0;
    public bool isValid = true;
    private static Color valid = new Color(0, 1f, 0, 0.5f);
    private static Color invalid = new Color(1f, 0f, 0, 0.5f);

    void Start () {
        isValid = true;
        activationCircle.color = valid;
        trigger.GetComponent<TriggerEnterBroadcaster>().listeners += Entered;
        trigger.GetComponent<TriggerExitBroadcaster>().listeners += Exited;
    }

    void Entered(GameObject g, int p) {
        currentCollisions++;
        activationCircle.color = invalid;
        isValid = false;
    }

    void Exited(GameObject g, int p) {
        currentCollisions--;
        if (currentCollisions == 0) {
            activationCircle.color = valid;
            isValid = true;
        }
    }

}

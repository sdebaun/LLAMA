using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class CreepController : NetworkBehaviour {

    public Damageable damage;
    public Animation legacyAnimation;

    private NightPhase night;

    public static List<GameObject> items = new List<GameObject>();

    void Start() {
        if (isServer) {
            night = GameObject.Find("NightPhase").GetComponent<NightPhase>();
            damage.onDeath.AddListener((GameObject g) => { night.CountDeath(); });
        }
        if (isClient) {
            legacyAnimation.Play("walk");
        }
    }
}

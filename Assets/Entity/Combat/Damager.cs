using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Damager : NetworkBehaviour {

    public TargetManager targeter;
    public float damagePerSecond = 1f;

    void Update() {
        if (isServer && (targeter.currentTarget != null)) {
            Damageable d = targeter.currentTarget.GetComponent<Damageable>();
            if (d) { d.takeDamage(damagePerSecond * Time.deltaTime); }
        }
    }

}

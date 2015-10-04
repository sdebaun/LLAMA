using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Damageable : NetworkBehaviour {

    [SyncVar]
    public float maxHealth = 100f;

    [SyncVar]
    public float currentHealth = 100f;

    public ParticleSystem gibs;

    public void takeDamage(float d) {
        currentHealth -= d;
        if (currentHealth <= 0f) { Destroy(gameObject); }
    }

    public override void OnNetworkDestroy() {
        // this is where you would put any client fx
        Instantiate(gibs, transform.position, transform.rotation);
    }

    public override void OnStartServer() {
        currentHealth = maxHealth;
    }
}

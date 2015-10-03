using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Damageable : NetworkBehaviour {

    [SyncVar]
    public float maxHealth = 100f;

    [SyncVar]
    public float currentHealth = 100f;

    public void takeDamage(float d) {
        currentHealth -= d;
        if (currentHealth <= 0f) {
            Debug.Log("I am dead, Horatio! -- " + gameObject.name);
            Destroy(gameObject);
        }
    }

    public override void OnStartServer() {
        currentHealth = maxHealth;
    }
}

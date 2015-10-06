using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Damageable : NetworkBehaviour {

    public delegate void KillListener();
    public event KillListener killListeners;

    [SyncVar]
    public float maxHealth = 100f;

    [SyncVar]
    public float currentHealth = 100f;

    public GameObject gibs;

    public void takeDamage(float d) {
        currentHealth -= d;
        if (currentHealth <= 0f) { Kill(); }
    }

    public void Kill() {
        if (killListeners!=null) killListeners();
        RpcKilled();
        Destroy(gameObject);
    }

    [ClientRpc]
    public void RpcKilled() {
        if (gibs != null) { Instantiate(gibs, transform.position, transform.rotation); }
    }

    public override void OnStartServer() {
        currentHealth = maxHealth;
    }
}

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using System;
using System.Collections.Generic;

[Serializable]  
public class DeathEvent : UnityEvent<GameObject> { }

public class Damageable : NetworkBehaviour {

    [SyncVar]
    public float maxHealth = 100f;
    [SyncVar]
    public float currentHealth = 100f;

    public DeathEvent onDeath = new DeathEvent();
    public GameObject gibs;

    private bool isDead = false;

    public override void OnStartServer() {
        currentHealth = maxHealth;
    }

    public void takeDamage(float d) {
        if (isDead) return;
        currentHealth -= d;
        if (currentHealth <= 0f) Kill();
    }

    [Server]
    public void Kill() {
        GameObject g;
        if (gibs != null) {
            g = Instantiate(gibs, transform.position, transform.rotation) as GameObject;
            NetworkServer.Spawn(g);
        }
        isDead = true;
        onDeath.Invoke(gameObject);
        Destroy(gameObject);
    }

}

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.Networking;
using System;


[Serializable] public class DeathEvent : UnityEvent<GameObject> { }
[Serializable] public class HealthChangeEvent : UnityEvent<float> { }

public delegate void DestroyDelegate(GameObject g);

public class Damageable : NetworkBehaviour {

    [SyncVar] public float maxHealth = 100f;
    [SyncVar] public float currentHealth = 100f;

    public HealthChangeEvent onHealthChange = new HealthChangeEvent();
    public DeathEvent onDeath = new DeathEvent();

    private bool isDead = false;

    public DestroyDelegate Destroyer = Destroy;

    public override void OnStartServer() {
        currentHealth = maxHealth;
    }

	// XXX zack: Our unit tests will warn if we have this on. :(
    //[Server]
    public void takeDamage(float d) {
        if (isDead) return;
        currentHealth -= d;
        onHealthChange.Invoke(currentHealth);
        if (currentHealth <= 0f) Kill();
    }

	// XXX zack: Our unit tests will warn if we have this on. :(
    //[Server]
    public void Kill() {
        isDead = true;
        onDeath.Invoke(gameObject);
        Destroyer(gameObject);
    }
}

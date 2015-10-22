using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.Networking;
using System;


[Serializable] public class DeathEvent : UnityEvent<GameObject> { }
[Serializable] public class HealthChangeEvent : UnityEvent<float> { }

public class Damageable : NetworkBehaviour {

    [SyncVar] public float maxHealth = 100f;
    [SyncVar] public float currentHealth = 100f;

    public HealthChangeEvent onHealthChange = new HealthChangeEvent();
    public DeathEvent onDeath = new DeathEvent();

    private bool isDead = false;

    public override void OnStartServer() {
        currentHealth = maxHealth;
    }

	public void zack(float d) {
        currentHealth -= d;
        // Tried this, doesn't cause test to fail. :(
        //Assert.IsTrue (false);

        // Tried this, since Unity isn't running, I dont think events get fired.
        onHealthChange.Invoke(currentHealth);
	}

    //[Server]
    public void takeDamage(float d) {
        if (isDead) return;
        currentHealth -= d;
        onHealthChange.Invoke(currentHealth);
        if (currentHealth <= 0f) Kill();
    }

    //[Server]
    public void Kill() {
        isDead = true;
        onDeath.Invoke(gameObject);
        Destroy(gameObject);
    }

}

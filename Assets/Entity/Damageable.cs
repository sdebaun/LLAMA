﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Damageable : NetworkBehaviour {

    public delegate void KillListener();
    public event KillListener killListeners;
    private bool isDead = false;

    [SyncVar]
    public float maxHealth = 100f;

    [SyncVar]
    public float currentHealth = 100f;

    public GameObject gibs;

    public void takeDamage(float d) {
        if (isDead) return;
        currentHealth -= d;
        if (currentHealth <= 0f) { Kill(); }
    }

    [Server]
    public void Kill() {
        GameObject g;
        if (gibs != null) {
            g = Instantiate(gibs, transform.position, transform.rotation) as GameObject;
            NetworkServer.Spawn(g);
        }
        isDead = true;
        if (killListeners!=null) killListeners();
        //RpcKilled(); // nope not this either, gets triggered after object destroyed
        Destroy(gameObject);
    }

    // can't use OnDestroy because it triggers after game end as well (or do we care?)
    //[ClientRpc]
    //public void RpcKilled() {
    //    if (gibs != null) { Instantiate(gibs, transform.position, transform.rotation); }
    //}

    public override void OnStartServer() {
        currentHealth = maxHealth;
    }
}

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Assertions;

using System.Collections;
using System.Diagnostics.CodeAnalysis;

public class WumpusController : ControllerBehaviour {
	new public static string baseInstanceName = "WumpusController";

	private GameObject go;
	private Damageable damageable;
	private Animation anim;
	private Animator anim2;

	public WumpusController() {
		Debug.Log ("WumpusController()");

		// TODO: Currently we're adding Damageable to the WumpusController, is that right?
		go = this.gameObject;
		anim = go.GetComponentInChildren<Animation>();

		// TODO (zack): Playing with Horse
		anim2 = go.GetComponentInChildren<Animator>();

		damageable = go.AddComponent<Damageable> ();
		damageable.currentHealth = 10f;
		damageable.maxHealth = 10f;
	}

	// TODO: Example behavior to prove it works. This will go away.
	IEnumerator MoveRandomlyAndTakeDamage() {
		go.transform.position = Random.insideUnitSphere * 2;
		damageable.takeDamage (1);
		yield return new WaitForSeconds(.5f);
		StartCoroutine ("MoveRandomlyAndTakeDamage");
	}

	// TODO Network stuff
	void Start() {
		Debug.Log ("WumpusController Start");

		if (isServer) {
			damageable.onDeath.AddListener((GameObject g) => {Debug.Log ("Wumpus is dead!"); });
		}

		//if (isClient) {

		if (anim != null) {
			anim.Play("walk");
		}
		if (anim2 != null) {
			Debug.Log ("Animator");
//			RuntimeAnimatorController controller = new RuntimeAnimatorController();
//			anim2.runtimeAnimatorController = controller;
//			controller.
//				.Play ("Horse_Run");
		}

		StartCoroutine("MoveRandomlyAndTakeDamage");
	}
}


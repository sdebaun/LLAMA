using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Assertions;

using System.Collections;
using System.Diagnostics.CodeAnalysis;

public class WumpusController : ControllerBehaviour {
	new public static string baseInstanceName = "WumpusController";

	private GameObject go;
	private Damageable damageable;

	public WumpusController() {
		Debug.Log ("WumpusController()");

		// TODO: Currently we're adding Damageable to the WumpusController, is that right?
		go = this.gameObject;
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

		// TODO: Animation not working yet.
		//if (isClient) {
		//	go.GetComponent<Animation>().Play("walk");
		//}

		StartCoroutine("MoveRandomlyAndTakeDamage");
	}
}


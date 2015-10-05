using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {

	public int destroyDelay = 10;

	// Use this for initialization
	void Start () {
		StartCoroutine (DieDelay());
	}

	IEnumerator DieDelay() {
		yield return new WaitForSeconds(destroyDelay);
		Destroy (gameObject);
	}
}

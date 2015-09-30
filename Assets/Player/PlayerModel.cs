using UnityEngine;
using System.Collections;

public class PlayerModel : MonoBehaviour {

    public Color color;

	// Use this for initialization
	void Start () {
        color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

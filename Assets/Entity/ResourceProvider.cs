using UnityEngine;
using System.Collections;

public class ResourceProvider : MonoBehaviour {

    public enum Type { Food, Energy, Smithore };

    public Type type = Type.Food;
    public int quantity = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

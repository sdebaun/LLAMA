using UnityEngine;
using System.Collections;

// used in trees, rocks in scene prefabs
public class ResourceProvider : MonoBehaviour {

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

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

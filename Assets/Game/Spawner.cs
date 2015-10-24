using UnityEngine;
using System.Collections;

public class Controller : Component {
//	static private T obj;
//
//	//public GameObject Spawn(Transform transform) {
//	public GameObject Spawn() {
//		return Object.Instantiate (T);
//	}


}

// WumpusController should attach all the other component behaviours it needs and wire them together appropriately
// WumpusController can also attach "asset prefabs" which would be meshes, animations, sounds, etc, that have a few connection points that get wired to the controller behaviors
// TODO: Singleton?
public class WumpusController : Controller {
	public Wumpus wumpus;

	public WumpusController() {
		Debug.LogError ("WumpusController");
		wumpus = new Wumpus ();
	}

	public void Spawn() {
		Instantiate<Wumpus> (wumpus);
	}
}

public class Wumpus : MonoBehaviour {
	public void Awake() {
		Debug.LogError ("ZACK2");
	}
}

// The "spawn a wumpus" call should create a new gameobject and attach a wumpuscontroller to it
// XXX zack: not sure if this is a class that you new, or just a static thing.
// SpawnControlledObject<controller_class>(optional_transform) -> GameObject that has been instantiated (that has a Controller attached to it)
public class Spawner<T> where T : Controller {
	//static public T controller;

	public static GameObject SpawnControlledObject () {
		// TODO: name?
		// TODO: transform
		GameObject gameObject = new GameObject ();
		//Controller<T> controller = new Controller<T> ();
		gameObject.AddComponent<T>();
		return gameObject;
	}
}

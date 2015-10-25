using UnityEngine;
using UnityEngine.Assertions;

using System.Collections;

// TODO This is just a temporary class because I wanted to isolate this new behavior until I knew it worked.
//      Next step is to merge just a few lines of this code into the DayPhase.
public class ThingThatSpawnsWumpus : BaseBehaviour {

	public GameObject wumpus_prefab;

	void Start() {

		Debug.Log ("ThingThatSpawnsWumpus: Start");

		// TODO Reading online suggested that prefabs must go in a Resources directory to be loaded
		//      OR we can expose a wumpus_prefab that we hook together in the Unity UI.
		//      
		//      The question is, which do we prefer?
		GameObject prefab = (GameObject)Resources.Load ("Wumpus");
		GameObject wumpus = InstantiateControlledPrefab<WumpusController>(prefab);
		//GameObject wumpus = InstantiateControlledPrefab<WumpusController>(wumpus_prefab);

		// TODO: Change things about the Wumpus that we care about here, like its starting location.
		wumpus.transform.position.Set (0, 0, -10);
	}
}
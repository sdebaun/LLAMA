using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Assertions;

/*
All of our classes (at least those that instantiate objects) will inherit from BaseBehaviour
TODO: Do some hacky multiple-inheritance equivalent (possibly Extension Methods) for MonoBehavior
TODO: Also add a SpawnControlled<T> which does the same thing as InstantiateControlled
      but then follows up with a NetworkServer.Spawn() on the newly Instantiated game object.
      SpawnControlled<T> will be needed on both MonoBehaviour and NetworkBehaviour
      because there will be server-side MB that need to spawn network objects
*/

// XXX zack: Make this NetworkBehaviour
public class BaseBehaviour : NetworkBehaviour {

	// TODO: Is there a reason to expose the GameObject?
	public GameObject InstantiateControlled<T>(Vector3 position, Quaternion rotation) where T : ControllerBehaviour {
        GameObject g = new GameObject(BaseInstanceNameOf<T>());
        g.transform.position = position;
        g.transform.rotation = rotation;
        g.AddComponent<T>();
        return g;
    }

    public GameObject InstantiateControlled<T>() where T : ControllerBehaviour {
        return InstantiateControlled<T>(Vector3.zero, Quaternion.identity);
    }

	// TODO: Test me
	public GameObject InstantiateControlledPrefab<T>(GameObject prefab, Vector3 position, Quaternion rotation) where T : ControllerBehaviour {
		Assert.IsNotNull (prefab);

		GameObject g = (GameObject)Instantiate(prefab, position, rotation);
		g.name = BaseInstanceNameOf<T>();
		g.AddComponent<T>();

		// TODO: I don't know what this does yet. Should the Controller do this?
		//NetworkServer.Spawn (g);
		return g;
	}

	// TODO: Test me
	public GameObject InstantiateControlledPrefab<T>(GameObject prefab) where T : ControllerBehaviour {
		return InstantiateControlledPrefab<T>(prefab, Vector3.zero, Quaternion.identity);
	}
	
	private string BaseInstanceNameOf<T>() where T : ControllerBehaviour {
        return typeof(T).GetField("baseInstanceName").GetValue(null) as string;
    }
}

/*
Controllers inherit from this and specify their baseInstanceName
*/
public class ControllerBehaviour : BaseBehaviour {
    public static string baseInstanceName = "ControlledObject";
}

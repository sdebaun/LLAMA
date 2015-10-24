using UnityEngine;
using System.Collections;

/*
All of our classes (at least those that instantiate objects) will inherit from BaseBehaviour
Do some hacky multiple-inheritance equivalent for an extended NetworkBehaviour
Also add a SpawnControlled<T> which does the same thing as InstantiateControlled
but then follows up with a NetworkServer.Spawn() on the newly Instantiated game object.
SpawnControlled<T> will be needed on both MonoBehaviour and NetworkBehaviour
because there will be server-side MB that need to spawn network objects
*/
public class BaseBehaviour : MonoBehaviour {

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

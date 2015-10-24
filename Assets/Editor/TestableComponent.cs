using UnityEngine;
using System.Collections.Generic;

// This class allows us to test MonoBehavior classes without Unity warning us not to
// instantiate new Monobehavior classes.
public class TestableComponent<T> where T : Component {

    private static List<GameObject> gameObjects = new List<GameObject>();

    public GameObject gameObject;
    public T component;

    public TestableComponent() {
        gameObject = new GameObject();
        component = gameObject.AddComponent<T>();
        gameObjects.Add(gameObject);
    }

    public static void CleanUp() {
        foreach (GameObject g in gameObjects) { GameObject.DestroyImmediate(g); }
    }
}
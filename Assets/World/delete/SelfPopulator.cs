using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SelfPopulator : MonoBehaviour {

    public GameObject[] prefabs;

    void Start() { // because OnStartServer only called if object is NetworkServer.Spawn'd
        if (NetworkServer.active) {
            GameObject g = Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position, Random2dRotation()) as GameObject;
            NetworkServer.Spawn(g);
            g.GetComponent<NetworkParent>().SetParent(transform.parent.gameObject);
        }
    }

    public Quaternion Random2dRotation() {
        Vector2 v = Random.insideUnitCircle;
        return Quaternion.LookRotation(new Vector3(v.x, 0, v.y));
    }

}

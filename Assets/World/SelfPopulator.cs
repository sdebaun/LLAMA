using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SelfPopulator : MonoBehaviour {

    public GameObject[] prefabs;

    void Start() { // because OnStartServer only called if object is NetworkServer.Spawn'd
        if (NetworkServer.active) Populate();
    }

    //[Server]
    public void Populate() { 
        GameObject g = Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position, Random2dRotation()) as GameObject;
        g.transform.SetParent(transform, false);
        NetworkServer.Spawn(g);
        g.GetComponent<NetworkParent>().SetParent(transform.parent.gameObject);
        //g.transform.SetParent(transform, false);
    }
    //public void Populate(GameObject parent) { // because OnStartServer only called if object is NetworkServer.Spawn'd
    //    GameObject g = Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position, Random2dRotation()) as GameObject;
    //    NetworkServer.Spawn(g);
    //    g.GetComponent<NetworkParent>().SetParent(parent);
    //    //g.transform.SetParent(transform, false);
    //}

    public Quaternion Random2dRotation() {
        Vector2 v = Random.insideUnitCircle;
        return Quaternion.LookRotation(new Vector3(v.x, 0, v.y));
    }

}

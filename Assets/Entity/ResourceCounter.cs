using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ResourceCounter : NetworkBehaviour {

    public GameObject triggerObject;

    public ResourceProvider.Type type = ResourceProvider.Type.Food;

    [SyncVar]
    public int quantity = 0;

    // Use this for initialization
    void Start() {
        //if (enabled = isServer) {
            triggerObject.GetComponent<TriggerEnterBroadcaster>().listeners += Spotted;
            triggerObject.GetComponent<TriggerExitBroadcaster>().listeners += Lost;
        //}
    }

    [Server]
    public void Spotted(GameObject target, int priority) {
        print("detected resource");
        ResourceProvider rp = target.GetComponent<ResourceProvider>();
        if (rp && (rp.type == type)) quantity += rp.quantity;
        print("new quantity " + quantity);
    }

    [Server]
    public void Lost(GameObject target, int priority) {
        print("lost resource");
        ResourceProvider rp = target.GetComponent<ResourceProvider>();
        if (rp && (rp.type == type)) quantity -= rp.quantity;
        print("new quantity " + quantity);
    }
}

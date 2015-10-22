using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ResourceCounter : MonoBehaviour {

    public ResourceProvider.Type type = ResourceProvider.Type.Food;

    public QuantityChangeEvent onChange = new QuantityChangeEvent();

    public int amount=0;

    public void Spotted(GameObject target, int priority) {
        print("detected resource");
        ResourceProvider rp = target.GetComponent<ResourceProvider>();
        if (rp && (rp.type == type)) onChange.Invoke(amount += rp.quantity);
    }

    public void Lost(GameObject target, int priority) {
        print("lost resource");
        ResourceProvider rp = target.GetComponent<ResourceProvider>();
        if (rp && (rp.type == type)) onChange.Invoke(amount -= rp.quantity);
    }
}

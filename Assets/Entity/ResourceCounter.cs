using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// used in extractghostsmithore, some resourcetrigger somewhere
public class ResourceCounter : MonoBehaviour {

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

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

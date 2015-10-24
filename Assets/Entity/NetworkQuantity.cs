using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

[Serializable] public class QuantityChangeEvent : UnityEvent<int> { }

// used in: ColonyCenter
public class NetworkQuantity : NetworkBehaviour {

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    public string label;

    [SyncVar(hook ="OnSync")]
    public int amount = 0;
    private void OnSync(int i) {
        onChange.Invoke(amount = i);
    }

    public QuantityChangeEvent onChange = new QuantityChangeEvent();

    public override void OnStartClient() {
        onChange.Invoke(amount);
    }
}

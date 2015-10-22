using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

[Serializable] public class QuantityChangeEvent : UnityEvent<int> { }

public class NetworkQuantity : NetworkBehaviour {

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

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

[Serializable] public class ToggleChangeEvent : UnityEvent<bool> { }

public class NetworkToggle : NetworkBehaviour {

    public string label;

    public ToggleChangeEvent onChange = new ToggleChangeEvent();
    public UnityEvent onChangeTrue = new UnityEvent();
    public UnityEvent onChangeFalse = new UnityEvent();

    [SyncVar(hook ="OnSync")]
    public bool value = false;
    private void OnSync(bool b) { UpdateListeners(); }

    public override void OnStartClient() { UpdateListeners(); }

    private void UpdateListeners() {
        onChange.Invoke(value);
        if (value) onChangeTrue.Invoke();
        else onChangeFalse.Invoke();
    }
}

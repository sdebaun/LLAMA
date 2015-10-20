using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class NetworkToggle : NetworkBehaviour {

    public UnityEvent OnTrue = new UnityEvent();
    public UnityEvent OnFalse = new UnityEvent();

    [SyncVar(hook = "OnSync")]
    public bool value;
    void OnSync(bool b) {
        if (value = b) OnTrue.Invoke();
        else OnFalse.Invoke();
    }

}

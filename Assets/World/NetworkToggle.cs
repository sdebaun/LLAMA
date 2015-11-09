using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public interface INetworkToggle {
    void Set(bool val);
}

public class NetworkToggle : NetworkBehaviour, INetworkToggle {

    public UnityEvent OnTrue = new UnityEvent();
    public UnityEvent OnFalse = new UnityEvent();

    public void Set(bool val) { value = val; }

    [SyncVar(hook = "OnSync")]
    public bool value;
    void OnSync(bool b) {
        if (value = b) OnTrue.Invoke();
        else OnFalse.Invoke();
    }

}

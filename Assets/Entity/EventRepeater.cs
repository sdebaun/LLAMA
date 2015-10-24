using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;

// used in GrowPhase
public class EventRepeater : NetworkBehaviour {

    public float minDelay = 0.5f;
    public float maxDelay = 1.0f;

    public UnityEvent OnTrigger = new UnityEvent();

    public void Begin(float min, float max) {
        minDelay = min; maxDelay = max;
        StartCoroutine(Tick());
    }
    public void Begin(UnityAction a) {
        OnTrigger.AddListener(a);
        Begin(minDelay, maxDelay);
    }
    public void Begin(UnityAction a, float min, float max) {
        OnTrigger.AddListener(a);
        Begin(minDelay, maxDelay);
    }
    public void Begin() { Begin(minDelay, maxDelay); }


    public void End() {
        OnTrigger.RemoveAllListeners();
        StopAllCoroutines();
    }

    IEnumerator Tick() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            OnTrigger.Invoke();
        }
    }
}

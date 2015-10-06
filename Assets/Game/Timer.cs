using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Timer : NetworkBehaviour {

    [SyncVar]
    public int secondsLeft;

    public delegate void Callback();

    public void StartTimer(int s, Callback c) {
        StopAllCoroutines();
        secondsLeft = s;
        StartCoroutine(Countdown(c));
    }

    IEnumerator Countdown(Callback c) {
        while (secondsLeft > 0) {
            yield return new WaitForSeconds(1);
            secondsLeft--;
        }
        c();
    }
}

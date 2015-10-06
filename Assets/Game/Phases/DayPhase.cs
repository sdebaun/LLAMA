using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(Timer))]
public class DayPhase : Phase {

    public int secondsPerDay;

    public override void OnBegin() {
        GetComponent<Timer>().StartTimer(secondsPerDay, Next);
        game.turn += 1;
    }

    public override void OnEnd() {
        // ???
    }

}

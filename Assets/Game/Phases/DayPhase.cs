using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// used by gameobject with same name in World scene, child to Game
[RequireComponent(typeof(Timer))]
public class DayPhase : Phase {


    //public int secondsPerDay;
    public int towersPerDay = 3;

    [Server]
    public override void OnBegin() {
        GetComponent<Timer>().StartTimer(game.secondsPerDay, Next);
        //Sun sun = GameObject.Find("Sun").GetComponent<Sun>();
        //sun.enabled = true;
        //sun.RpcRise(secondsPerDay);
    }

    public override void OnEnd() {
        //GameObject.Find("Sun").GetComponent<Sun>().enabled = false;
    }

}

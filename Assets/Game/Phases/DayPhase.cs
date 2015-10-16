using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(Timer))]
public class DayPhase : Phase {

    public WorldLightController worldLight;

    public int secondsPerDay;
    public int towersPerDay = 3;

    [Server]
    public override void OnBegin() {
        GetComponent<Timer>().StartTimer(secondsPerDay, Next);
        game.turn += 1;
        worldLight.RotateToSunset(secondsPerDay);
        //Sun sun = GameObject.Find("Sun").GetComponent<Sun>();
        //sun.enabled = true;
        //sun.RpcRise(secondsPerDay);
    }

    public override void OnEnd() {
        //GameObject.Find("Sun").GetComponent<Sun>().enabled = false;
    }

}

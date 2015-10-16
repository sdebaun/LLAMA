using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(Timer))]
public class DayPhase : Phase {

    public int secondsPerDay;
    public int towersPerDay = 3;

    [Server]
    public override void OnBegin() {
        //foreach (GameObject p in GameObject.FindGameObjectsWithTag("Player")) {
        //    PlayerModel pm = p.GetComponent<PlayerModel>();
        //    Debug.Log("Updating towerbuilds on " + p.name);
        //    foreach (Builder b in pm.builder.builders) {
        //        b.AddBuilds(towersPerDay);
        //    }
        //}
        GetComponent<Timer>().StartTimer(secondsPerDay, Next);
        game.turn += 1;
        Sun sun = GameObject.Find("Sun").GetComponent<Sun>();
        sun.enabled = true;
        sun.RpcRise(secondsPerDay);
    }

    public override void OnEnd() {
        GameObject.Find("Sun").GetComponent<Sun>().enabled = false;
    }

}

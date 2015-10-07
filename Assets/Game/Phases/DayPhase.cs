using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(Timer))]
public class DayPhase : Phase {

    public int secondsPerDay;
    public int towersPerDay = 3;

    [Server]
    public override void OnBegin() {
        foreach (GameObject p in GameObject.FindGameObjectsWithTag("Player")) {
            PlayerModel pm = p.GetComponent<PlayerModel>();
            Debug.Log("Updating towerbuilds on " + p.name);
            pm.AddTowerBuilds(towersPerDay);
        }
        GetComponent<Timer>().StartTimer(secondsPerDay, Next);
        game.turn += 1;
    }

    public override void OnEnd() {
        // ???
    }

}

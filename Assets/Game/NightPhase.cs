using UnityEngine;
using System.Collections;

public class NightPhase : Phase {

    // these should be part of a creep/camp/xeno manager?
    public int unspawnedCreeps = 0;
    public int spawnedCreeps = 0;

    public override void OnBegin() {
        // make all spawns live
    }

    public override void OnEnd() {
        // ???
    }
}

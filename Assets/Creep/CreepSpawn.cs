using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CreepSpawn : NetworkBehaviour {

    public GameObject creepPrefab;
    public float ghostInterval;

    // only public so they'll show up in inspector
    public float maxInterval;
    public float nextSpawnDelay;
    public int creepsLeft;

    // for callbacks on creep count
    private GamePhase phase;

    public string state = "";

    public override void OnStartServer() {
        phase = GameObject.Find("GameManager").GetComponent<GamePhase>();
    }

    public void StopSpawns() {
        StopAllCoroutines();
    }

    public void StartLive(int creepsToSpawn, float maxSpawningDuration) {
        Debug.Log("Spawner starting LIVE mode");
        state = "live";
        creepsLeft = creepsToSpawn;
        maxInterval = maxSpawningDuration / creepsToSpawn;
        StopAllCoroutines();
        StartCoroutine(LiveSpawn());
    }

    IEnumerator LiveSpawn() {
        while ((state == "live") && (creepsLeft > 0)) {
            yield return new WaitForSeconds(nextSpawnDelay);
            SpawnNewCreep();
            phase.trackCreepSpawn();
            creepsLeft--;
            nextSpawnDelay = Random.Range(0.5f, 1f) * maxInterval;
        }
    }

    public GameObject SpawnNewCreep() {
        GameObject c = Instantiate(creepPrefab,transform.position,transform.rotation) as GameObject;
        NetworkServer.Spawn(c);
        return c;
    }

    public void StartGhost() {
        state = "demo";
        nextSpawnDelay = ghostInterval;
        StopAllCoroutines();
        StartCoroutine(GhostSpawn());
    }

    IEnumerator GhostSpawn() {
        while (state=="demo") {
            SpawnNewGhost();
            yield return new WaitForSeconds(nextSpawnDelay);
        }
    }

    public void SpawnNewGhost() {
        SpawnNewCreep().GetComponent<Creep>().isGhost = true;
    }

}

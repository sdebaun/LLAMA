using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CreepSpawn : NetworkBehaviour {

    public GameObject creepPrefab;

    // only public so they'll show up in inspector
    public float maxInterval;
    public float nextSpawnDelay;
    public int creepsLeft;

    public string state = "";

    void Start() {
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
            SpawnNewCreep();
            creepsLeft--;
            nextSpawnDelay = Random.Range(0.5f, 1f) * maxInterval;
            yield return new WaitForSeconds(nextSpawnDelay);
        }
    }

    public GameObject SpawnNewCreep() {
        GameObject c = Instantiate(creepPrefab,transform.position,transform.rotation) as GameObject;
        NetworkServer.Spawn(c);
        //c.transform.position = transform.position;
        return c;
    }

    public void StartGhost(float interval) {
        state = "demo";
        nextSpawnDelay = interval;
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

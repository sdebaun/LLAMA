using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CampController : NetworkBehaviour {

    public PeriodicSpawner ghostSpawner;
    public LimitedPeriodicSpawner liveSpawner;

    private DayPhase dayPhase;

    public override void OnStartServer() {
        dayPhase = GameObject.Find("DayPhase").GetComponent<DayPhase>();
    }

    public void BeginLive(int count, float maxSpawnDuration) {
        ghostSpawner.End();
        DestroyAllSpawned();
        liveSpawner.Begin(count, maxSpawnDuration * 0.5f, maxSpawnDuration);
    }

    public void DestroyAllSpawned() {
        liveSpawner.DestroySpawned();
        ghostSpawner.DestroySpawned();
    }

    public void BeginGhost() {
        liveSpawner.End();
        DestroyAllSpawned();
        ghostSpawner.Begin();
    }

    public void End() {
        ghostSpawner.End();
        liveSpawner.End();
    }

    //public GameObject creepPrefab;

    //public GameObject ghostPrefab;
    //public float ghostInterval;

    //// only public so they'll show up in inspector
    //public float nextSpawnDelay;
    //public int creepsLeft;

    //// for callbacks on creep count
    //private GamePhase phase;

    //public override void OnStartServer() {
    //    phase = GameObject.Find("GameManager").GetComponent<GamePhase>();
    //}

    //public void StopSpawning() {
    //    StopAllCoroutines();
    //}
    //public void SetSpawningLive(int creepCount, float maxInterval) {
    //    creepsLeft = creepCount;
    //    StopAllCoroutines();
    //    StartCoroutine(PeriodicSpawn(creepPrefab, maxInterval * 0.5f, maxInterval));
    //}
    //public void SetSpawningGhost(float interval) {
    //    StopAllCoroutines();
    //    StartCoroutine(PeriodicSpawn(ghostPrefab, interval));
    //}

    //IEnumerator PeriodicSpawn(GameObject prefab, float minSpawnInterval, float maxSpawnInterval = 0) {
    //    nextSpawnDelay = minSpawnInterval;
    //    while (true) {
    //        if (maxSpawnInterval > 0f) { nextSpawnDelay = Random.Range(minSpawnInterval, maxSpawnInterval); }
    //        yield return new WaitForSeconds(nextSpawnDelay);
    //        if (prefab.Equals(creepPrefab)) { // live
    //            if (creepsLeft > 0) {
    //                SpawnCreep(prefab);
    //                phase.trackCreepSpawn();
    //                creepsLeft--;
    //            }
    //        } else { // its a ghost
    //            SpawnCreep(prefab);
    //        }
    //    }
    //}

    //public void SpawnCreep(GameObject prefab) {
    //    GameObject c = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
    //    NetworkServer.Spawn(c);
    //}

}

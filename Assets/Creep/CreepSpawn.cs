using UnityEngine;
using System.Collections;

public class CreepSpawn : MonoBehaviour {

    public int spawn_count;  // number of spawn waves
    public int num_creeps;  // creeps per wave
    public int spawn_delay;  // seconds between waves
    public GameObject creep_to_spawn;

    void Start() {
        StartCoroutine(SpawnCreeps());
    }

    IEnumerator SpawnCreeps () {
        for (int i = 0; i < spawn_count; i++) {
            Creep new_creep;
            new_creep = Instantiate(creep_to_spawn, this.transform.position, this.transform.rotation) as Creep;
            //new_creep.SetGoal(goal);
            yield return new WaitForSeconds(spawn_delay);
        }
    }

	void Update () {
	
	}
}

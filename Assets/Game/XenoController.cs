using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public interface IXenoController {
    void StartSpawning(int count, float duration);
    UnityEvent OnCreepSpawn { get; set; }
    UnityEvent OnCreepDeath { get; set; }
}

public class Coroutine {
    public delegate bool PeriodicAction();

    public static IEnumerator Periodic(PeriodicAction action, float min = 0f, float max = 0f) {
        bool again = true;
        while (again) {
            yield return new WaitForSeconds(max == 0 ? min : Random.Range(min, max));
            again = action();
        }
    }
}

// used in "Game" object in world scene
public class XenoController : NetworkBehaviour, IXenoController {

    public GameObject prefab;
    public float minSpawnDistance, maxSpawnDistance;
    private int creepsRemaining;

    private UnityEvent _OnCreepSpawn = new UnityEvent();
    public UnityEvent OnCreepSpawn { get { return _OnCreepSpawn; } set { _OnCreepSpawn = value; } }

    private UnityEvent _OnCreepDeath = new UnityEvent();
    public UnityEvent OnCreepDeath { get { return _OnCreepDeath; } set { _OnCreepDeath = value; } }

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    //public string campTag = "Camp";

    //public List<CampController> FindAllCamps() {
    //    Debug.LogError("DEPRECATED, WHY ARE YOU CALLING THIS");
    //    return GameObject.FindGameObjectsWithTag(campTag).Select<GameObject, CampController>(item => item.GetComponent<CampController>()).ToList();
    //}

    public void StartSpawning(int count, float duration) {
        print("StartSpawning " + count + " " + duration);
        creepsRemaining = count;
        StartCoroutine(Coroutine.Periodic(SpawnOne));
    }

    public bool SpawnOne() {
        Vector2 randomPerimeterPosition = UnityEngine.Random.insideUnitCircle.normalized * Random.Range(minSpawnDistance, maxSpawnDistance);
        GameObject g = Instantiate(prefab, randomPerimeterPosition, Quaternion.identity) as GameObject;
        g.GetComponent<Damageable>().onDeath.AddListener((GameObject dead) => { OnCreepDeath.Invoke(); });
        NetworkServer.Spawn(g);
        OnCreepSpawn.Invoke();
        creepsRemaining--;
        //creeps.Add(g);
        //if (countListeners != null) countListeners();
        return (creepsRemaining > 0);
    }

}

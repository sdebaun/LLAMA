using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class ExtractController : NetworkBehaviour {

    public NetworkQuantity quantity;
    public ResourceCounter potential;

    public float minDelay = 0.75f;
    public float maxDelay = 1.25f;

    public static List<ExtractController> items = new List<ExtractController>();
    public override void OnStartServer() {
        base.OnStartServer();
        items.Add(this);
        Damageable d = GetComponent<Damageable>();
        if (d) d.onDeath.AddListener(Killed);
    }

    public static void Killed(GameObject g) {
        items.Remove(g.GetComponent<ExtractController>());
    }

    public delegate void GenerationDone();

    private GenerationDone callback;
    public void StartGenerating(GenerationDone newCallback) {
        callback = newCallback;
        StartCoroutine(PeriodicGeneration(potential.amount + Random.Range(-3,3)));
    }

    IEnumerator PeriodicGeneration(int productionRemaining) {
        while (productionRemaining > 0) {
            yield return new WaitForSeconds(Random.Range(minDelay,maxDelay));
            productionRemaining--;  quantity.amount++;
        }
        callback();
    }

}

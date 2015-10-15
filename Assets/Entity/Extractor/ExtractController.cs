using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class ExtractController : NetworkBehaviour {

    public int maxProduction;
    public int currentResources;

    public static List<ExtractController> items = new List<ExtractController>();
    public override void OnStartServer() {
        base.OnStartServer();
        items.Add(this);
        Damageable d = GetComponent<Damageable>();
        if (d) d.onDeath.AddListener(Killed);
    }

    public delegate void GenerationDone();

    private GenerationDone callback;
    public void StartGenerating(GenerationDone newCallback) {
        callback = newCallback;
        maxProduction = Random.Range((int)4, (int)10);
        StartCoroutine(PeriodicGeneration());
    }

    IEnumerator PeriodicGeneration() {
        while (currentResources < maxProduction) {
            yield return new WaitForSeconds(0.5f);
            currentResources++;
        }
        callback();
    }

    public static void Killed(GameObject g) {
        items.Remove(g.GetComponent<ExtractController>());
    }
}

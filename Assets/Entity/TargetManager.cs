using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

/*
used in player prefab
Hooks up to events that 
*/
public class TargetManager : NetworkBehaviour {

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    public struct PrioritizedTarget {
        public GameObject gameObject;
        public int priority;
    }

    public List<GameObject> triggerObjects = new List<GameObject>();

    private List<PrioritizedTarget> targetQueue = new List<PrioritizedTarget>();
    private PrioritizedTarget currentPrioritizedTarget;

    [SyncVar]
    private bool hasTarget = false;

    public GameObject currentTarget;

    [SyncVar(hook = "OnTargetNetID")]
    public NetworkInstanceId targetNetID;
    void OnTargetNetID(NetworkInstanceId id) {
        //print("Client update currentTarget " + id);
        if (!id.IsEmpty()) currentTarget = ClientScene.FindLocalObject(id);
    }

    void Update() {
        if (isServer && targetIsGone()) ClearTarget();
        if (!hasTarget && (targetQueue.Count>0)) SetNextTarget();
    }

    void Start() {
        if (enabled = isServer) { // yes, assignment: turn this off if its not on the server
            foreach (GameObject t in triggerObjects) { // hook up my triggers
                t.SetActive(true);
                t.GetComponent<TriggerEnterBroadcaster>().listeners += Spotted;
                t.GetComponent<TriggerExitBroadcaster>().listeners += Lost;
            }
        } else {
            triggerObjects.ForEach(x => x.SetActive(false));
        }
        if (isClient) OnTargetNetID(targetNetID);
    }

    [Server]
    public void Spotted(GameObject gameObject, int priority) {
        PrioritizedTarget newPrioritizedTarget = new PrioritizedTarget { gameObject = gameObject, priority = priority };
        targetQueue.Add(newPrioritizedTarget);
        if (!hasTarget || (newPrioritizedTarget.priority > currentPrioritizedTarget.priority))
            SetTarget(newPrioritizedTarget);
    }

    [Server]
    public void Lost(GameObject target, int priority) {
        PrioritizedTarget lostTarget = targetQueue.Find(x => x.gameObject == target);
        //print("Remove target, now " + targetQueue.Count + " left");
        targetQueue.Remove(lostTarget);
        //print("After remove: currentTarget is " + currentTarget.gameObject);
        if (currentTarget.gameObject == lostTarget.gameObject) SetNextTarget();
    }

    private void ClearTarget() {
        targetQueue.Remove(currentPrioritizedTarget);
        targetNetID = NetworkInstanceId.Invalid;
        currentTarget = null;
        hasTarget = false;
    }

    private bool targetIsGone() { return hasTarget && !currentPrioritizedTarget.gameObject; }

    [Server]
    private void SetNextTarget() {
        targetQueue.Sort((x, y) => x.priority.CompareTo(y.priority) * -1);
        while ((targetQueue.Count > 0) && !currentTarget) {
            if (targetQueue[0].gameObject) SetTarget(targetQueue[0]);
            else targetQueue.RemoveAt(0);
        }
    }

    [Server]
    private void SetTarget(PrioritizedTarget t) {
        targetNetID = t.gameObject.GetComponent<NetworkIdentity>().netId;
        currentPrioritizedTarget = t;
        currentTarget = t.gameObject;
        hasTarget = true;
    }

}

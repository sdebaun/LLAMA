using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Attack : NetworkBehaviour {

    public TriggerTarget targeter;
    public AttackEffect attackEffect;
    public float damagePerSecond = 1f;
    public float maxLockDistance = 3f;

    // do not modify, but display in inspector
    public GameObject target;

    [SyncVar(hook = "OnTargetNetID")]
    public NetworkInstanceId targetNetID;
    void OnTargetNetID(NetworkInstanceId id) {
        if (!id.IsEmpty()) {
            target = ClientScene.FindLocalObject(id);
            if (target) {
                attackEffect.switchTo(target);
                return;
            }
        }
        attackEffect.disable();
    }

    void Update() {
        if (isServer) {
            if (target) { // shoot that shit
                Damageable d = target.GetComponent<Damageable>();
                if (d) { d.takeDamage(damagePerSecond * Time.deltaTime); }
            }
            if ((target == null) || (distanceToTarget() > maxLockDistance)) {
                clearTarget();
                targeter.findNearbyTarget();
            }
        }
    }

    public float distanceToTarget() {
        return target ? Vector3.Distance(transform.position, target.transform.position) : 0f;
    }

    // will need to make a command for this if client can select target
    public void setTarget(GameObject g) {
        target = g;
        targetNetID = g.GetComponent<NetworkIdentity>().netId;
    }

    public void clearTarget() {
        target = null;
        targetNetID = NetworkInstanceId.Invalid;
    }

}

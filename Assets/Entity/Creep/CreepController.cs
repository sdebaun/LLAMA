using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

// any network behaviours have to be attached to the prefab !?!?!
// because it is that asset that gets spawned on the client with no state
// then it is up to the OnStart[Server|Client] to AddComponent appropriately
// with MonoBehaviours only!!!
public class CreepController : NetworkBehaviour {

    private NightPhase night;

    public override void OnStartServer() {
        base.OnStartServer();

        // needs a rigidbody only because the networktransform needs one for smoothing
        // on the networktransform: using synctransform mode with no rigidbody causes jitter on client
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true;  // physical 'cause' only, does not react to forces
        GetComponent<NetworkTransform>().transformSyncMode = NetworkTransform.TransformSyncMode.SyncRigidbody3D;

        gameObject.AddComponent<Damageable>();

        Seeker s = gameObject.AddComponent<Seeker>();

        Navigator n = gameObject.AddComponent<Navigator>();
        n.seeker = s;
        n.destinationName = "ColonyCenter";
        n.moveSpeedMin = 0.5f;
        n.moveSpeedMax = 1.0f;
        n.nextWaypointDistance = 1f;

        //GameObject attack = Instantiate(Resources.Load("Effects/Attack/Laser")) as GameObject;
        //attack.transform.SetParent(gameObject.transform);

        //TargetManager targeter = gameObject.AddComponent<TargetManager>();
        //targeter.NewTargetEvent += laser.SetTargetObject();

        // this dont work either
        //NetworkTransform nt = gameObject.AddComponent<NetworkTransform>();
    }

    public override void OnStartClient() {
        base.OnStartClient();
        print("OnStartClient");

        GameObject mesh = Instantiate(Resources.Load("Entity/Creep/CreepMesh")) as GameObject;
        mesh.transform.SetParent(gameObject.transform,false);
        mesh.GetComponent<Animation>().Play("walk");

        GetComponent<NetworkTransform>().transformSyncMode = NetworkTransform.TransformSyncMode.SyncRigidbody3D;

        // this dont work either
        //NetworkTransform nt = gameObject.AddComponent<NetworkTransform>();
    }

    // this dont do what youd hope it would do
    //public void Start() {
    //    NetworkTransform nt = gameObject.AddComponent<NetworkTransform>();
    //}

}
//public class CreepController : ControllerBehaviour {

//    public Damageable damage;
//    public Animation legacyAnimation;

//    private NightPhase night;

//    public static List<GameObject> items = new List<GameObject>();

//    public void Start() {
//        if (isServer) {
//            night = GameObject.Find("NightPhase").GetComponent<NightPhase>();
//            damage.onDeath.AddListener((GameObject g) => { night.CountDeath(); });
//        }
//        if (isClient) {
//            legacyAnimation.Play("walk");
//        }
//    }
//}

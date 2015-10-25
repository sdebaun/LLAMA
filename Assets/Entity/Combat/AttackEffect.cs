using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AttackEffect : NetworkBehaviour {

    public GameObject source;
    public TargetManager targeter;

    public LineRenderer pewpew;
    public AudioSource sfx;

    // Use this for initialization
    void Start () {
        pewpew.SetWidth(0.2f, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
        //print(isClient + " " + isServer + " " + targeter);
        if (targeter && targeter.currentTarget) {
            pewpew.enabled = true;
            pewpew.SetPosition(0, source.transform.position);
            pewpew.SetPosition(1, targeter.currentTarget.transform.position);
            if (sfx && !sfx.isPlaying) sfx.Play();
        } else if (pewpew.enabled) {
            pewpew.enabled = false;
            if (sfx && sfx.isPlaying) sfx.Stop();
        }
    }
}

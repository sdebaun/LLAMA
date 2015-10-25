using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections.Generic;

// used in readyroomphase object in world scene
public class FluffMaker : NetworkBehaviour {

    public Text ui;

    public List<string> labels = new List<string>();
    public List<string> values = new List<string>();
    public int lines = 4;

    [SyncVar(hook = "UpdateFluff")]
    public string fluff;

    public override void OnStartServer() { Generate(); }

    public override void OnStartClient() { UpdateFluff(fluff); }

    // called from client as syncvar hook, or on server from game logic
    void UpdateFluff(string s) {
        ui.text = fluff = s;
    }

    public void Generate() {
        PickList<string> lab = new PickList<string>(labels);
        PickList<string> val = new PickList<string>(values);

        string text = "";
        for (int i = 0; i < 4; i++) {
            text += lab.Pick() + ": " + val.Pick() + "\n\r";
        }
        UpdateFluff(text);
    }
	
}

public class PickList<T> : List<T> {
    public PickList(List<T> l) : base(l) { }

    public T Pick() {
        int i = Random.Range(0, Count);
        T retval = this[i];
        RemoveAt(i);
        return retval;
    }
};


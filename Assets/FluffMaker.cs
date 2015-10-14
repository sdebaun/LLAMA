using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FluffMaker : MonoBehaviour {

    public List<string> labels = new List<string>();
    public List<string> values = new List<string>();
    public int lines = 4;

	// Use this for initialization
	void Start () {
        Generate();
	}

    public void Generate() {
        string text = "";
        for (int i = 0; i < 4; i++) {
            text += PickFluff() + "\n\r";
        }
        GetComponent<Text>().text = text;
    }

    string PickFluff() {
        return labels[Random.Range(0, labels.Count)] + ": " + values[Random.Range(0, values.Count)];
    }
	
}

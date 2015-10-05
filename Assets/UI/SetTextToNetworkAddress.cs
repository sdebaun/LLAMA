using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetTextToNetworkAddress : MonoBehaviour {

    public GameObject lanWarningLabel;

    // Use this for initialization
    void Start() {
        string ip = Network.player.ipAddress;
        gameObject.GetComponent<Text>().text = ip;
        if (lanWarningLabel) lanWarningLabel.SetActive(ip.Substring(0, 3) == "192");
    }

}

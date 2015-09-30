using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerListControl : MonoBehaviour {

    public GameObject playerRowPrefab;

    private List<PlayerModel> players = new List<PlayerModel>();
    private List<GameObject> rows = new List<GameObject>();

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Add(PlayerModel p) {
        players.Add(p);
        GameObject newRow = Instantiate(playerRowPrefab);
        rows.Add(newRow);
        newRow.GetComponent<PlayerRowControl>().setPlayer(p);
        newRow.transform.SetParent(transform, false);
        newRow.transform.position = new Vector3(newRow.transform.position.x, newRow.transform.position.y - (40 * (rows.Count-1)), newRow.transform.position.z);
    }
}

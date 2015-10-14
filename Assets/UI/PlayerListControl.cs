using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerListControl : MonoBehaviour {

    public GameObject playerRowPrefab;
    public GameObject localPlayerRowPrefab;

    private List<PlayerModel> players = new List<PlayerModel>();
    private List<GameObject> rows = new List<GameObject>();

    public void Add(PlayerModel p, bool isLocal=false) {
        players.Add(p);
        GameObject newRow = Instantiate(isLocal ? localPlayerRowPrefab : playerRowPrefab);
        newRow.transform.SetParent(gameObject.transform);
        rows.Add(newRow);
        newRow.GetComponent<PlayerRowControl>().setPlayer(p);
    }

    public void Remove(PlayerModel p) {
        players.Remove(p);
        foreach (GameObject row in rows) {
            if (row.GetComponent<PlayerRowControl>().isForPlayer(p)) {
                GameObject.Destroy(row);
                rows.Remove(row);
                return;
            }
        }
    }
}

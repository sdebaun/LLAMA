using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerListControl : MonoBehaviour {

    public GameObject playerRowPrefab;

    private List<PlayerModel> players = new List<PlayerModel>();
    private List<GameObject> rows = new List<GameObject>();

    public void Add(PlayerModel p) {
        players.Add(p);
        GameObject newRow = Instantiate(playerRowPrefab);
        rows.Add(newRow);
        newRow.GetComponent<PlayerRowControl>().setPlayer(p);
        newRow.transform.SetParent(transform, false);
        float delta = -1 * (40 * (rows.Count - 1));
        newRow.transform.localPosition = new Vector3(newRow.transform.localPosition.x, newRow.transform.localPosition.y + delta, newRow.transform.localPosition.z);
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

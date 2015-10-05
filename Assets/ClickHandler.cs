using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System.Collections;

public class ClickHandler : MonoBehaviour {

    public GameObject prefab;

	public void DoThing(BaseEventData e) {
        PointerEventData p = e as PointerEventData;
        //p.pointerPressRaycast.worldPosition;

        Vector3 worldPosition = p.pointerPressRaycast.worldPosition;
        //worldPosition.y = 0;
        Debug.Log("mouse button " + (p as PointerEventData).button + " at screen " + p.position + " world " + worldPosition);
        GameObject g = Instantiate(prefab, worldPosition, Quaternion.identity) as GameObject;
        NetworkServer.Spawn(g);

    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

// used by the ground in the world scene to connect input events to local player
public class PlayerClickHandler : MonoBehaviour {

    public PlayerModel localPlayer;

    public void HandleEvent(BaseEventData e) {
        if (localPlayer != null) localPlayer.HandlePointerEvent(e as PointerEventData);
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerClickHandler : MonoBehaviour {

    public PlayerModel localPlayer;

    public void HandleEvent(BaseEventData e) {
        if (localPlayer != null) localPlayer.HandlePointerEvent(e as PointerEventData);
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerClickHandler : MonoBehaviour {

    public PlayerModel localPlayer;

    public void HandleEvent(BaseEventData e) {
        if (localPlayer != null) {
            // Need to handle touch events differently across the board
            if (Input.touches.Length >= 0) {
                Debug.Log("Handling a touch event");
                localPlayer.HandleTouchEvent(e as PointerEventData);
            }
            else {
                localPlayer.HandlePointerEvent(e as PointerEventData);
            }
        }
    }
}

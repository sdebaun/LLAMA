using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// attached to ground
public class UseCursor : MonoBehaviour {

    public Texture2D cursorTexture;

    //public void Awake() { Debug.LogError("NO DEPRECATE! Used in " + gameObject.name); } // DEPRECATION TRIGGER

    public void Activate() {
        //print("Using custom cursor");
        Cursor.SetCursor(cursorTexture, new Vector2(16,16), CursorMode.ForceSoftware);
    }

    public void Deactivate() {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}


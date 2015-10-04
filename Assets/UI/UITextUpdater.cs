using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Reflection;

public class UITextUpdater : MonoBehaviour {
    public GameObject sourceGameObject; // in editor or WatchSource() at runtime
    public string sourceComponentName = "Damageable";
    public string sourceFieldName = "currentHealth";
    public bool floatToWholeNumber = true;
    public bool intToTime = false;

    private Text destText;
    private FieldInfo sourceFieldInfo;
    private Component sourceComponent;

    void Start() {
        destText = GetComponent<Text>();
        StartWatching(sourceGameObject);
    }

    void Update() {
        if (sourceGameObject && destText) destText.text = GetSourceText();
    }

    private string GetSourceText() {
        object val = sourceFieldInfo.GetValue(sourceComponent);
        if (floatToWholeNumber) return ((float)val).ToString("N0");
        if (intToTime) return timeString((int)val);
        return val.ToString();
    }

    public void StartWatching(GameObject go, string field = null) {
        if (!go) {
            sourceGameObject = null;  sourceComponent = null;  sourceFieldInfo = null;
            return;
        }
        if (field!=null) sourceFieldName = field;
        sourceGameObject = go;
        sourceComponent = sourceGameObject.GetComponent(sourceComponentName);
        sourceFieldInfo = sourceComponent.GetType().GetField(sourceFieldName);
    }

    private string timeString(int s) {
        string f = "";
        if (s > 60) { f += (int)(s / 60) + ":"; } else { f += "0:"; }
        int ss = s % 60;
        if (ss < 10) { f += "0"; }
        f += ss;
        return f;
    }
}
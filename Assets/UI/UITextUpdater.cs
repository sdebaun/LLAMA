using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Reflection;

// used: all over the place
public class UITextUpdater : MonoBehaviour {
    public Component sourceComponent;

    //public GameObject sourceGameObject; // in editor or WatchSource() at runtime
    //public string sourceComponentName = "Damageable";
    public string sourceFieldName = "currentHealth";
    public bool floatToWholeNumber = true;
    public bool intToTime = false;

    private Text destText;
    private TextMesh destTextMesh;
    private FieldInfo sourceFieldInfo;
    private PropertyInfo sourcePropertyInfo;

    void Start() {
        destText = GetComponent<Text>();
        destTextMesh = GetComponent<TextMesh>();
        StartWatching(sourceComponent);
    }

    void Update() {
        if (sourceComponent && (destText || destTextMesh)) { // SO HAX
            if (destText) destText.text = GetSourceText();
            if (destTextMesh) destTextMesh.text = GetSourceText();
        }
    }

    private string GetSourceText() {
        object val = null;
        if (sourceFieldInfo!=null) {
            val = sourceFieldInfo.GetValue(sourceComponent);
            if (floatToWholeNumber) return ((float)val).ToString("N0");
            if (intToTime) return timeString((int)val);
        }
        if (sourcePropertyInfo!=null) {
            val = sourcePropertyInfo.GetValue(sourceComponent,null);
            if (floatToWholeNumber) return ((float)val).ToString("N0");
            if (intToTime) return timeString((int)val);
        }
        return val.ToString();
    }

    public void StartWatching(Component c, string field = null) {
        if (!c) {
            sourceComponent = null;  sourceFieldInfo = null;
            return;
        }
        if (field!=null) sourceFieldName = field;
        sourceComponent = c;
        sourceFieldInfo = sourceComponent.GetType().GetField(sourceFieldName);
        if (sourceFieldInfo== null) { sourcePropertyInfo = sourceComponent.GetType().GetProperty(sourceFieldName); }
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
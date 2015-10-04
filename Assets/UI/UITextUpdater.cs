using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Reflection;

public class UITextUpdater : MonoBehaviour {
    public GameObject sourceGameObject; // in editor or WatchSource() at runtime
    public string sourceComponentName = "Damageable";
    public string sourceFieldName = "currentHealth";
    public bool floatToWholeNumber = true;

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
        return floatToWholeNumber ? ((float)val).ToString("N0") : val.ToString();
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

}
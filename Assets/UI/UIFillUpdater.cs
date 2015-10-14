using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Reflection;

public class UIFillUpdater : MonoBehaviour {
    public Component sourceComponent;

    public string sourceFieldName = "currentHealth";
    public string maxFieldName = "maxHealth";

    private Image destImage;
    private FieldInfo sourceFieldInfo, maxFieldInfo;

    void Start() {
        destImage = GetComponent<Image>();
        StartWatching(sourceComponent);
    }

    void Update() {
        if (sourceComponent && destImage) { // SO HAX
            destImage.fillAmount = GetSourceFill();
        }
    }

    private float GetSourceFill() {
        object cur = sourceFieldInfo.GetValue(sourceComponent);
        object max = maxFieldInfo.GetValue(sourceComponent);
        float c, m;
        float.TryParse(cur.ToString(), out c);
        float.TryParse(max.ToString(), out m);
        return c / m;
    }

    public void StartWatching(Component c, string field = null) {
        if (!c) {
            sourceComponent = null;  sourceFieldInfo = null;
            return;
        }
        if (field!=null) sourceFieldName = field;
        sourceComponent = c;
        sourceFieldInfo = sourceComponent.GetType().GetField(sourceFieldName);
        maxFieldInfo = sourceComponent.GetType().GetField(maxFieldName);
    }
}
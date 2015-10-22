using UnityEngine;
using UnityEngine.UI;

public class FillController : MonoBehaviour {

    public int current, max;
    public Image fillImage;

    public void UpdateAmount(int i) {
        current = i;
        SetFillAmount();
    }
    public void UpdateMax(int i) {
        max = i;
        SetFillAmount();
    }
    private void SetFillAmount() { fillImage.fillAmount = (float)current / (float)max; }
}

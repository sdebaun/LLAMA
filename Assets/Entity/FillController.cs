using UnityEngine;
using UnityEngine.UI;

// used in UI bars all over the place
public class FillController : MonoBehaviour {

    //public void Awake() { print("FillController: " + gameObject.name); }

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

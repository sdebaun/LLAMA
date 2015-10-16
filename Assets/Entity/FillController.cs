using UnityEngine;
using UnityEngine.UI;

public class FillController : MonoBehaviour {

    public int max;
    public Image fillImage;

    public void UpdateAmount(int i) {
        fillImage.fillAmount = (float)i / (float)max;
    }

}

using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Image healthFill;

    public void SetHealth(float current, float max)
    {
        float fillAmount = Mathf.Clamp01(current / max);
        if (healthFill != null)
            healthFill.fillAmount = fillAmount;
    }
}

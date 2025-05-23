using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform cam; 
    public Image fillImage;

    public void SetHealth(float current, float max)
    {
        if (fillImage != null)
        {
            fillImage.fillAmount = current / max;
        }
    }

    void LateUpdate()
    {
        if (cam != null)
        {
            transform.LookAt(transform.position + cam.forward); 
        }
    }
}

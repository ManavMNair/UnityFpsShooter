using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float floatHeight = 0.5f;
    private Vector3 startPos;

    void Start() => startPos = transform.localPosition;

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.localPosition = new Vector3(startPos.x, newY, startPos.z);
    }
}

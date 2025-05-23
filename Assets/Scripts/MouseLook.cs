using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 500f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Up/down rotation on the camera
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Left/right rotation on the player body
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

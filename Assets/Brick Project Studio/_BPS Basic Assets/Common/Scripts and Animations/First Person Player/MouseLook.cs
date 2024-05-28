using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseXSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        this.transform.localEulerAngles = Vector3.zero;
    }

    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseXSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseXSensitivity;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
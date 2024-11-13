using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercamer : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    private Transform playerBody;
    public float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform.parent;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        int size = 10;
        Rect rect = new Rect(Screen.width / 2 - size / 2, Screen.height / 2 - size / 2, size, size);
        GUI.Box(rect, "•");
    }
}

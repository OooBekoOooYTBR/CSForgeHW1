using System;
using UnityEngine;
using UnityEngine.Events;

public class CameraMove : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    private float yaw = 0f; // Yatay dönüş
    private float pitch = 0f; // Dikey dönüş

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        // --- Fare ile bakış ---
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -80f, 80f); // Yukarı-aşağı sınırlama
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}
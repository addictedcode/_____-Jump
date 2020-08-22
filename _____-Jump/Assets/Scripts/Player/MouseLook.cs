using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform cam;

    [SerializeField] private float mouseSensitivity = 1f;

    float xRotation = 0f;
    float yRotation = 0f;

    float averageMouseX = 0f;
    float averageMouseY = 0f;

    float oldMouseX = 0f;
    float oldMouseY = 0f;

    float mouseX = 0f;
    float mouseY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        smoothingRotation();
        getRotation();
        look();
    }

    private void getInput()
    {
        oldMouseX = mouseX;
        oldMouseY = mouseY;

        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");
    }

    private void look()
    {
        cam.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        player.localRotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    private void getRotation()
    {
        xRotation -= averageMouseY * mouseSensitivity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += averageMouseX * mouseSensitivity;
    }

    private void smoothingRotation()
    {
        averageMouseX = (oldMouseX + mouseX) * 0.5f;
        averageMouseY = (oldMouseY + mouseY) * 0.5f;
    }
}

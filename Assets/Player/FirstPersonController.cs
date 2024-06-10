using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float mouseSensitivity = 2.0f;
    public float walkSpeed = 5.0f;

    private float verticalRotation = 0;
    private CharacterController characterController;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Player movement
        float moveDirectionX = Input.GetAxis("Horizontal");
        float moveDirectionZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = (transform.TransformDirection(Vector3.forward) * moveDirectionZ) +
                               (transform.TransformDirection(Vector3.right) * moveDirectionX);
        moveDirection.Normalize();

        characterController.SimpleMove(moveDirection * walkSpeed);
    }
}

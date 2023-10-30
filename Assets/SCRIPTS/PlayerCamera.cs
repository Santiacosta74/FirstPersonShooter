using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCamera : MonoBehaviour
{
    public float sensitivity = 2.0f; 
    public float minimumX = -90f;
    public float maximumX = 90f;  
    public Transform player; 

    private float rotationX = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    { 
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        player.transform.Rotate(Vector3.up * mouseX);
    }
}

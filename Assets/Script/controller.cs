using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class controller : MonoBehaviour
{
    public float moveSpeed = 150f;
    public float turnSpeed = 400f;
    public float zoomSpeed = 100f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0f;
    private float rotationY = 0f;

    public landscape_gen landscape;

    private void Start()
    {
        landscape= GameObject.FindObjectOfType<landscape_gen>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            // Move camera forward/backward and strafe left/right
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
            transform.position += transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime;

            // Rotate camera left/right (yaw) and up/down (pitch)
            rotationX += Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, -90f, 90f); // Prevent camera from flipping upside-down
            transform.rotation = Quaternion.Euler(-rotationY, rotationX, 0f);
            UnityEngine.Cursor.visible = false;
        }

        else
        {
            UnityEngine.Cursor.visible = true;
        }

        if (Input.GetKey(KeyCode.A)) { landscape.transform.RotateAround(landscape.GetComponent<Renderer>().bounds.center, Vector3.up, turnSpeed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.E)) { landscape.transform.RotateAround(landscape.GetComponent<Renderer>().bounds.center, Vector3.up, -turnSpeed * Time.deltaTime); }

        // Zoom camera in/out using scroll wheel
        transform.position += transform.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // public GameObject example;
    public float rotationSpeed = 50f;  // Speed of rotation in degrees per second
    public float minRotation = -45f;  // Minimum rotation angle
    public float maxRotation = 45f;   // Maximum rotation angle
    public Vector3 rotationAxis = Vector3.up; // Axis to rotate around (default is Y-axis)

    private float currentAngle = 0f;  // Current angle of rotation
    private bool rotatingForward = true; // Direction of rotation

    // Update is called once per frame
    void Update()
    {
        // Calculate rotation step
        float rotationStep = rotationSpeed * Time.deltaTime;

        // Check if rotating forward or backward
        if (rotatingForward)
        {
            currentAngle += rotationStep;
            if (currentAngle >= maxRotation)
            {
                currentAngle = maxRotation;
                rotatingForward = false; // Reverse direction
            }
        }
        else
        {
            currentAngle -= rotationStep;
            if (currentAngle <= minRotation)
            {
                currentAngle = minRotation;
                rotatingForward = true; // Reverse direction
            }
        }

        // Apply rotation to the object
        transform.localRotation = Quaternion.Euler(rotationAxis * currentAngle);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotationAngle = 15f;
    public float edgeThreshold = 0.9f;
    public float smoothSpeed = 5f;
    public float turnCooldown = 0.5f; 

    private Quaternion defaultRotation; 
    private Quaternion rightRotation;
    private Quaternion leftRotation; 
    private Quaternion targetRotation;

    private float cooldownTimer = 0f;

    void Start()
    {
        defaultRotation = transform.rotation;

        rightRotation = Quaternion.Euler(
            defaultRotation.eulerAngles.x,
            defaultRotation.eulerAngles.y + rotationAngle,
            defaultRotation.eulerAngles.z
        );

        leftRotation = Quaternion.Euler(
            defaultRotation.eulerAngles.x,
            defaultRotation.eulerAngles.y - rotationAngle,
            defaultRotation.eulerAngles.z
        );

        targetRotation = defaultRotation;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0)
        {
            float mouseX = Input.mousePosition.x / Screen.width;

            if (mouseX > edgeThreshold)
            {
                targetRotation = rightRotation;
                cooldownTimer = turnCooldown;
            }
            else if (mouseX < 1 - edgeThreshold)
            {
                targetRotation = leftRotation;
                cooldownTimer = turnCooldown;
            }
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
    }
}
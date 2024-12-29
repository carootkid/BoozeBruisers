using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraRotate : MonoBehaviour
{
    public float rotationAngle = 15f;
    public float edgeThreshold = 0.9f; 
    public float smoothSpeed = 5f; 

    private Quaternion defaultRotation; 
    private Quaternion rightRotation;
    private Quaternion targetRotation; 

    void Start()
    {
        
        defaultRotation = transform.rotation;

        //makes the camera move to the right a certain amount amount and angle shit i dont care about because i looked up how to move it right!!!!!!!!
        rightRotation = Quaternion.Euler(
            defaultRotation.eulerAngles.x,
            defaultRotation.eulerAngles.y + rotationAngle,
            defaultRotation.eulerAngles.z
        );
        //RETREAT!!!!!!!!!!!!!!!!
        targetRotation = defaultRotation;
    }

    void Update()
    {
        float mouseX = Input.mousePosition.x / Screen.width;

        if (mouseX > edgeThreshold)
        {
            targetRotation = rightRotation;
        }
        
        else if (mouseX < 1 - edgeThreshold)
        {
            targetRotation = defaultRotation;
        }
        //move the dinglebob
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
    }
}
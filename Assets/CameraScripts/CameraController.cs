using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Quaternion targetRotation;
    public float rotationSpeed = 1.0f;

    void Start()
    {
        transform.position = player.transform.position;
        targetRotation = transform.rotation;
    }

    void UpdateTargetRotation(string direction)
    {
        if (direction == "left")
        {
            targetRotation *= Quaternion.Euler(0, 90, 0);
        }
        else if (direction == "right")
        {
            targetRotation *= Quaternion.Euler(0, -90, 0);
        }
    }

    void LateUpdate()
    {
        transform.position = player.transform.position;
        
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            UpdateTargetRotation("left");
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            UpdateTargetRotation("right");
        }
        
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}

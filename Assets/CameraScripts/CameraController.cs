using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    void Start()
    {
        transform.position = player.transform.position;
    }

    void Move90Degrees(string direction)
    {
        if (direction == "left")
        {
            transform.Rotate(0, 90, 0);
        }
        else if (direction == "right")
        {
            transform.Rotate(0, -90, 0);
        }
    }

    void LateUpdate()
    {
        transform.position = player.transform.position;
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            Move90Degrees("left");
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            Move90Degrees("right");
        }
    }
}

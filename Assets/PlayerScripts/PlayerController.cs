using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    public GameObject MainCamera;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        winTextObject.SetActive(false);
        count = SpawnerSelector.count;
        rb = GetComponent <Rigidbody>();
        SetCountText();
    }

    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y;
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

   void SetCountText()
   {
       countText.text = "Count: " + count.ToString();
       if (count == 0)
       {
           winTextObject.SetActive(true);
       }
   }

   private void FixedUpdate()
   {
        Vector3 movement = new Vector3 (MainCamera.transform.forward.x * movementY, 0.0f, MainCamera.transform.forward.z * movementY);
        rb.AddForce(movement * speed);
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            Move90Degrees("left");
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            Move90Degrees("right");
        }
   }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count--;
            SetCountText();
        }
        
    }
}

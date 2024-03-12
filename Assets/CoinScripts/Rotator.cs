using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    /*
    void Start()
    {
        // postion Y = -5
        transform.position = new Vector3(0.0f, -6.0f, 0.0f);
        // Rotation X = 45, Y = 45, Z = 45
        transform.rotation = Quaternion.Euler(45, 45, 45);   
    }
    */

 void Update()
    {
        transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
    }
 
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other) // OnCollisionEnter2D(): This method is called to detect collisions between objects.
    {
        Debug.Log("Touch!");
    }

    void OnTriggerEnter2D(Collider2D other) // OnTriggerEnter2D(): This method is called to detect when this object passes over another object.
    {
        Debug.Log("What was that?");
    }
}

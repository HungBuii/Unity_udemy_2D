using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;

    Rigidbody2D rb2d;

    SurfaceEffector2D surfaceEffector2D; // SurfaceEffector2D: https://docs.unity3d.com/Manual/class-SurfaceEffector2D.html

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>(); // FindObjectOfType: https://docs.unity3d.com/ScriptReference/Object.FindObjectOfType.html
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }

    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) // Old Input System
        {
            rb2d.AddTorque(torqueAmount); // Rotation Z-axis positive in 2D mode

            // AddTorque(): Apply a torque at the rigidbody's centre of mass. Applying torque
            // to the Rigidbody2D changes the "angularVelocity" only. This change 
            // is scaled (divided) by the rotational "inertia". Therefore, a
            // larger inertia results in smaller changes to angularVelocity, 
            // and a smaller inertia results in larger changes to angularVelocity. 
            // (https://docs.unity3d.com/ScriptReference/Rigidbody2D.AddTorque.html)

            // "angularVelocity": https://docs.unity3d.com/ScriptReference/Rigidbody2D-angularVelocity.html
            // "inertia": https://docs.unity3d.com/ScriptReference/Rigidbody2D-inertia.html
            // "angularDrag": https://docs.unity3d.com/ScriptReference/Rigidbody-angularDrag.html
            // "linearDrag": https://docs.unity3d.com/ScriptReference/Rigidbody2D-drag.html
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount); // Rotation Z-axis negative in 2D mode
        }
    }
}

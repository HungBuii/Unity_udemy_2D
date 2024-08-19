using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // SerializeField: Display member variable information to editable unity tool.
    [SerializeField] float steerSpeed = 100f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime; // Input.GetAxis("axisName"): control the rotation or 
                                                                                       // position object with A, D or left, right buttons on the horizontal axis.

                                                                      // mutiply "steerSpeed" to control the rotation speed.
                                                                      
                                                                      // Time.deltaTime: The actions in the game will be independent of the frame rate of the machine. 
                                                                      // If there are 2 fast and slow computers, then without "Time.deltaTime" the fast computer will act faster than the slow computer. 
                                                                      // Therefore, "Time.deltaTime" will help synchronize all computers to have the same action processing without having to depend on the frame rate of the computer.
        transform.Rotate(0, 0, -steerAmount); // Rotation(x, y, z)

                                             // When "steerAmount" is set to a positive value, the car will always move in the opposite direction of the car's rotation. 
                                             // For example, when pressing the A button, the car will move to the left in the direction the car is looking straight, 
                                             // but if "steerAmount" is a positive value, it will move to the right but should be on the left. 
                                             // Therefore, "-steerAmount" will be used to change the correct direction of the car's rotation.

            
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime; // Same "steerAmount"
        transform.Translate(0, moveAmount, 0); // Position(x, y, z)
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }
}

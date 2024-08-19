using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(0, 255, 26, 255); // Green (custom)
                                                                             // Color32: Color is in 32 bit format

                                                                             // Each color component is a byte value with a range from 0 to 255.

                                                                             // Components (r,g,b) define a color in RGB color space. 
                                                                             // Alpha component (a) defines transparency - alpha of 255 is completely opaque, 
                                                                             // alpha of zero is completely transparent.
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);

    bool hasPackage; // false
    [SerializeField] float destroyDelay = 0;


    SpriteRenderer spriteRenderer; // SpriteRenderer: Sprite Renderer component renders the Sprite and controls 
                                   // how it visually appears in a Scene for both 2D and 3D projects in Unity Tool Inspector.

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // GetComponent<Template>(): get component sprite "Cruisy McDriver" 
    } 


    public void OnCollisionEnter2D(Collision2D other) // OnCollisionEnter2D(): This method is called to detect collisions between objects.
    {
        Debug.Log("Touch!");
    }

    void OnTriggerEnter2D(Collider2D other) // other: game object
                                            // OnTriggerEnter2D(): This method is called to detect when this object passes over another object.
    {
        if (other.tag == "Package" && !hasPackage) // tag: tag in inspector in unity tool
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor; // change color in Sprite Renderer property by assigning it 
                                                    // to the object containing the Color parameter "hasPackageColor"

            Destroy(other.gameObject, destroyDelay); // Destroy(object, time): make an object disappear for a specified period of time.
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}

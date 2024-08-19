using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;

    // this things position (camera) should be the same as the car's position


    // Update is called once per frame
    // void Update()
    // {
    //     transform.position = thingToFollow.transform.position + new Vector3(0,0,-10);        
    // }

    void LateUpdate() // https://docs.unity3d.com/Manual/ExecutionOrder.html
    {
        transform.position = thingToFollow.transform.position + new Vector3(0,0,-10);        
    }
}

// using: https://docs.unity3d.com/Manual/Namespaces.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.html


public class FinishLine : MonoBehaviour
{

    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            finishEffect.Play();
            
            GetComponent<AudioSource>().Play(); // AudioSource: https://docs.unity3d.com/ScriptReference/AudioSource.html

            Invoke("ReloadScene", loadDelay); // Invoke: call a function (method) with a limited delay time

                                       // Invoke("name of method need call", timedelay): Invokes the method "methodName" in time seconds.

                                       // https://docs.unity3d.com/ScriptReference/MonoBehaviour.Invoke.html
        }   
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0); // LoadScene(): https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html
    }

}

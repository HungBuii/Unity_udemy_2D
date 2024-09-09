// using: https://docs.unity3d.com/Manual/Namespaces.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{

    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect; // ParticleSystem: https://docs.unity3d.com/ScriptReference/ParticleSystem.html

    [SerializeField] AudioClip crashSFX;

    bool hasCrash;

    void OnTriggerEnter2D(Collider2D other) 
    {   
        if (other.tag == "Ground" && !hasCrash)
        {
            hasCrash = true; // run statement 1 time no more. When Invoke() complete, hasCrash will reset value.
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX); // PlayOneShot(): https://docs.unity3d.com/ScriptReference/AudioSource.PlayOneShot.html
            Invoke("ReloadScene", loadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    
}

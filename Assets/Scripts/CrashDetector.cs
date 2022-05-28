using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem CrashEffect;
    [SerializeField] float Delay = 2f;
    [SerializeField] AudioClip CrashSFX;
    bool hasCrashed = false;

   void OnTriggerEnter2D(Collider2D other) 
   {
       if(other.tag == "Ground" && !hasCrashed)
       {
           hasCrashed = true;
           FindObjectOfType<PlayerController>().DisableControls();
           GetComponent<AudioSource>().PlayOneShot(CrashSFX);
           CrashEffect.Play();
           Invoke("ReloadScene", Delay);
       }
   } 
   void ReloadScene()
   {
       SceneManager.LoadScene(0);
   }
}

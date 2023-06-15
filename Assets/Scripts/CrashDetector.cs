using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] float finishDelay = 1.2f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground" && !hasCrashed){
            FindObjectOfType<PlayerController>().DisableMove();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            hasCrashed = true;
            Invoke("ReloadScene", finishDelay);
        }
    }
    
    void ReloadScene(){
            SceneManager.LoadScene("Level1");
    }
}

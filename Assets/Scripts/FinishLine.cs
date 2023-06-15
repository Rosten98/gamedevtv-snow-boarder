using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float finishDelay = 1.2f;
    [SerializeField] ParticleSystem finishEffect;
    AudioSource finishSFX;
    bool hasFinished = false;

    void Start() {
        finishSFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !hasFinished){
            finishEffect.Play();
            finishSFX.Play();
            hasFinished = false;
            Invoke("ReloadScene", finishDelay);
        }
    }

    void ReloadScene() {
            SceneManager.LoadScene("Level1");
    }
}

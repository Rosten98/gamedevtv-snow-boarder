using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem dustParticles;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.tag == "Ground")
            dustParticles.Play();
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.collider.tag == "Ground")
            dustParticles.Pause();
    }
}

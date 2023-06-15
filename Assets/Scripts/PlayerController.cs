using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 18f;
    [SerializeField] float baseSpeed = 15f;
    bool canMove = true;
    // Start is called before the first frame update
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        surfaceEffector2D.speed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableMove() {
        canMove = false;
    }

    void RespondToBoost()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            surfaceEffector2D.speed = boostSpeed;
        } else if(Input.GetKeyUp(KeyCode.Space)) {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}

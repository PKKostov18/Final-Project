using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterMovement controller;

    float horizontalMove = 0f;

    public float runSpeed = 40f;
    bool jump = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

       if(Input.GetButtonDown("Jump"))
       {
           jump = true;
       }

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump=false;
    }
}

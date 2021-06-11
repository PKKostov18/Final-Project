using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterMovement controller;
    public Animator animator;

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

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

       if(Input.GetButtonDown("Jump"))
       {
           jump = true;
            animator.SetBool("IfJumping", true);
       }

    }

    public void OnLanding ()
    {
        animator.SetBool("IfJumping", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump=false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;
    public AudioSource jumpSound;

    public float runSpeed = 40;    

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool cannotMove = false;

    public void ToggleMovement(bool status)
    {
        cannotMove = !status;
    }

	void Update() {
        if (cannotMove)
        {
            animator.SetFloat("Speed", 0);
            return;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jumpSound.Play();
        }

        if (Input.GetButton("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButton("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
	
	void FixedUpdate () {
        if (cannotMove)
            horizontalMove = 0;

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
	}
        
}

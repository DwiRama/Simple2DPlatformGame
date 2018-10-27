using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller; // Class that handles character physics
    public Animator animator;
    public AudioSource jumpSound;

    public float runSpeed = 40; //Amount of speed to give to a player

    float horizontalMove = 0f; //Movement Direction
    bool jump = false;
    bool cannotMove = false;

    public void ToggleMovement(bool status)
    {
        cannotMove = !status;
    }//

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
            if (!jumpSound.isPlaying)
                jumpSound.Play();
        }

        if (Input.GetButton("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

	void FixedUpdate () {
        if (cannotMove)
            horizontalMove = 0;

        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
	}
    
    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }//
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayerController : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public Transform CameraTrans;
    
    public float runSpeed = 40f;
    
    float horizontalMove = 0f;
//    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
//        if (Input.GetButtonDown("Jump"))
//        {
//            jump = true;
//            animator.SetBool("IsJumping", true);
//        }
        
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("CrouchingReversed", false);
        } else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("CrouchingReversed", true);
        }
    }
    
    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
    
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, false);
        Vector3 pos = CameraTrans.position;
        pos.x = transform.position.x + 0.87f;
        CameraTrans.position = pos;
//        jump = false;
    }

}

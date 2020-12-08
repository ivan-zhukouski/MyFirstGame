using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;
    float horizontalMove = 0f;

    void Update()
    {
        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        /*if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }*/

        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        
        } else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnLeftPointerDown()
    {
        horizontalMove = -1f * runSpeed;
    }
    public void OnLeftPointerUp()
    {
        horizontalMove = 0f;
    }
    public void OnRightPointerDown()
    {
        horizontalMove = 1f * runSpeed;
    }
    public void OnRightPointerUp()
    {
        horizontalMove = 0f;
    }
    
    public void JumpPointerDown()
    {
        jump = true;
    }
}

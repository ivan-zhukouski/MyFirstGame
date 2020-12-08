using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
  public bool isGrounded = false;
  Rigidbody2D rb;
  private PlayerDeath playerDeath;
  float moveSpeed = 7f;
  float jumpForce = 7f;
  float moveH;


  void Awake()
  {
      rb = GetComponent<Rigidbody2D>();
      playerDeath = GameObject.Find("Player").GetComponent<PlayerDeath>();
  }
    void FixedUpdate()
    {
      moveH = Input.GetAxis("Horizontal");
      transform.position += new Vector3(moveH, 0f,0f) * Time.deltaTime * moveSpeed;
    
      if(Input.GetButtonDown("Jump"))
      {
        rb.AddForce(new Vector2(0f, transform.position.y * jumpForce),ForceMode2D.Impulse);
      }
    }
    public void MovementLeft()
    {
       float moveH = Input.GetAxis("Horizontal");
    }
    public void MovementRight()
    {
       float moveH = Input.GetAxis("Horizontal");

       rb.velocity = new Vector3(moveH * moveSpeed, rb.velocity.y, rb.velocity.y);

       if((JoystickMovement.Instance.joyVec.y != 0 || JoystickMovement.Instance.joyVec.x !=0) && !playerDeath.isGameOver)
       {
           rb.velocity = new Vector3(JoystickMovement.Instance.joyVec.x, 
                                     JoystickMovement.Instance.joyVec.y, 
                                     JoystickMovement.Instance.joyVec.z) * moveSpeed;
       }
    }
    void Jump()
    {
      if(Input.GetButtonDown("Jump"))
      {
         rb.AddForce(new Vector2(0f, transform.position.y * jumpForce),ForceMode2D.Impulse);
      }
    }
}

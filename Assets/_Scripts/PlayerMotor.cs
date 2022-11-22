using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMotor : MonoBehaviour
{
    PlayerController controls;
    float direction = 0;

    public float speed = 200f;
    bool isFacingRight = true;
    public Rigidbody2D rigid;
    public Animator anim;

    public float jumpForce = 15;


    private void Awake()
    {
        controls = new PlayerController();
        controls.Enable();

        controls.Land.Move.performed += context => 
        {

            direction = context.ReadValue<float>();
        };

        controls.Land.Jump.performed  += context => Jump();

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
   

    private void FixedUpdate()
    {
        //Moving player left/right 
        rigid.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, rigid.velocity.y);
        anim.SetFloat("speed", Mathf.Abs(direction));

        //flip the player
        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
            Flip();
    }
 
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
  
    void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
    }
}
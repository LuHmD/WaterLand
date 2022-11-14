using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    

    public float speed;
    public Rigidbody2D rigid;
    private Animator anim;
    private float dirX;
    private bool facingRight = false;
    Vector3 localScale; //flip character to face towards where it goes
   

    private void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        speed = 5f;
    }

    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump") && rigid.velocity.y == 0)
            rigid.AddForce(Vector2.up * 700f);

        if (Mathf.Abs(dirX) > 0 && rigid.velocity.y == 0)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        if(rigid.velocity.y == 0) //if character not moving
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (rigid.velocity.y > 0) //Character goes UP
            anim.SetBool("isJumping", true);

        if(rigid.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);

        }
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(dirX, rigid.velocity.y);
    }

    private void LateUpdate()
    {
         if (dirX > 0)
             facingRight = false;
         else if (dirX < 0)
             facingRight = true; 

         if (((facingRight) && (localScale.x < 0)) || ((facingRight) && (localScale.x > 0)))
            localScale.x *= 1f;

         transform.localScale = localScale;
     }
    }

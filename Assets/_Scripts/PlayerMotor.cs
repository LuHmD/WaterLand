using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rigid;
    private Animator anim;
    private float dirX;
    private bool facingRight = true;

    public Transform feet;

    private bool isGrounded;

    Vector3 localScale; //flip character to face towards where it goes
    [SerializeField] float jumpForce;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        localScale = transform.localScale;
    }

    private void Update()
    {
        anim.SetBool("IsGrounded", isGrounded);
        RaycastHit2D hit = Physics2D.BoxCast(feet.transform.position, new Vector2(0.5f, 0.5f), 0, Vector2.down, .2f);
        if (hit)
            isGrounded = true;
        else
            isGrounded = false;

        if (isGrounded)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        dirX = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump") && isGrounded)
            rigid.velocity = Vector2.up * jumpForce;

        if (Mathf.Abs(dirX) > 0 && isGrounded)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);
        // 0.3 is skin margin for accuracey of transitions. 
        if (rigid.velocity.y > 0 + 0.3f) //Character goes UP
            anim.SetBool("isJumping", true);

        if (rigid.velocity.y < 0 + -0.3f)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }

        // handling slide. 
        if (Input.GetKeyDown(KeyCode.C) && isGrounded && Mathf.Abs(dirX) > 0)
        {
            speed = speed + 3; // speed boost for slide. 
            anim.SetTrigger("Slide"); 
        }
    }
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(dirX, rigid.velocity.y);
    }

    private void LateUpdate()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (facingRight)
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        else
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * -1f, transform.localScale.y);


        //if (((facingRight) && (localScale.x < 0)) || ((facingRight) && (localScale.x > 0)))
        //    localScale.x *= 1f;
        //transform.localScale = localScale;
    }
}

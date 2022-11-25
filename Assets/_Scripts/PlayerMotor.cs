using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMotor : MonoBehaviour
{
    public float speed = 5f;

    [SerializeField]
    private LayerMask collideWith;

    private float initialSpeed;
    private Rigidbody2D rigid;
    private Animator anim;
    private new SpriteRenderer renderer;

    private float dirX;
    private float moveX;
    private bool facingRight = true;

    public Transform feet;
    public Transform hip;
    public Transform playerSide;

    private bool isGrounded;
    private bool hitWall;

    // This will store the player sounds, then we can play using our Sound Singleton on actions (using events in the future)
    // See arrangement of clips in inspector. 
    public PlayerClips playerClips;

    Vector3 localScale; //flip character to face towards where it goes
    [SerializeField] float jumpForce;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        initialSpeed = speed;
        localScale = transform.localScale;
        SoundManager.Instance.PlayEffect(playerClips.playerSoundFx[0]);
    }

    private void Update()
    {
        print(hitWall + "Wall hit");
        Debug.DrawLine(hip.position, playerSide.position, Color.red);
        hitWall = Physics2D.Linecast(hip.position, playerSide.position, collideWith);
        if (hitWall)
        {
            speed = 0;
        }
        else
        {
            speed = initialSpeed;
        }
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

        dirX = Input.GetAxisRaw("Horizontal");
        moveX = dirX * speed;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            SoundManager.Instance.PlayEffect(playerClips.playerSoundFx[1]);
            rigid.velocity = Vector2.up * jumpForce;
        }

        if (Mathf.Abs(moveX) > 0 && isGrounded)
        {
            initialSpeed = 6;
            anim.SetBool("isRunning", true);
        }
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
        if (Input.GetKeyDown(KeyCode.C) && isGrounded && Mathf.Abs(moveX) > 0)
        {
            SoundManager.Instance.PlayEffect(playerClips.playerSoundFx[2]);
            // increaes velocity for slide. 
            initialSpeed = 9; // boost speed. 
            anim.SetTrigger("Slide");
        }
    }
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(moveX, rigid.velocity.y);
    }

    private void LateUpdate()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (facingRight)
        {
            renderer.flipX = false;
            playerSide.localPosition = new Vector2(Mathf.Abs(playerSide.localPosition.x), playerSide.localPosition.y);
            //transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else
        {
            renderer.flipX = true;
            // flipping side collider when the character flips. 

            playerSide.localPosition = new Vector2(Mathf.Abs(playerSide.localPosition.x) * -1, playerSide.localPosition.y);
            //transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * -1f, transform.localScale.y);
        }
    }

    public void FootStep()
    {
        SoundManager.Instance.PlayEffect(playerClips.playerSoundFx[3]);
    }
}
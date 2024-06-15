using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField]
    float playerMoveSpeed = 0f;
    [SerializeField]
    float playerJumpHeight = 0f;
    Rigidbody2D rb;
    float xPos = 0f;
    //string Horizontal = "Horizontal";
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    LayerMask groundLayer;
    float overLapCircleRadius = 0.5f;
    float playerJumpAdjuster = 0.5f;
    SpriteRenderer playerSprite;
    Animator PlayerAnimation;
    const string idlePlayer = "Idle Player";
    const string jumpPlayer = "Jump Player";
    const string runPlayer = "Run Player";
    bool moveLeft = false;
    bool moveRight = false;
    [SerializeField]
    AudioClip jumpSound;
    AudioSource src;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        PlayerAnimation = GetComponent<Animator>();
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      // xPos = Input.GetAxisRaw(Horizontal);
     
        PlayerJump();

        Flip(xPos);

        if (IsGrounded())
        {

            if (xPos != 0)
            {
                PlayerAnimationState(runPlayer);
            }
            else
            {
                
                PlayerAnimationState(idlePlayer);
            }
        }
        else
        {
            
            PlayerAnimationState(jumpPlayer);
        }

    }
    private void FixedUpdate()
    {
        if (moveLeft)
        {
            xPos = -1f;
        }
        else if (moveRight)
        {
            xPos = 1f;
        }
        else
        {
            xPos = 0f;
        }
        PlayerMove();
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, overLapCircleRadius, groundLayer);
    }

    void Flip(float direction)
    {
        if(direction>0)
        {
            playerSprite.flipX = false;
        }
        else if(direction<0)
        {
            playerSprite.flipX = true;
        }
    }
    
    void PlayerJump()
    {
        if (((Input.GetKeyDown(KeyCode.UpArrow)) ||(Input.GetKeyDown(KeyCode.Space))) && IsGrounded())
        {    
            rb.velocity = new Vector2(rb.velocity.x, playerJumpHeight);
            src.PlayOneShot(jumpSound);
        }

        if (((Input.GetKeyUp(KeyCode.UpArrow)) ||(Input.GetKeyUp(KeyCode.Space))) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * playerJumpAdjuster);
            
        }
       

    }

    void PlayerMove()
    {
        rb.velocity = new Vector2(xPos * playerMoveSpeed, rb.velocity.y);
        
    }

    void PlayerAnimationState(string currentState)
    {
        PlayerAnimation.Play(currentState);
    }

    public  void LeftMove()
    {

        moveLeft = true;
        
       
    }
    public void RightMove()
    {
        moveRight = true;
        
    }
    public void LeftUp()
    {

        moveLeft = false;


    }
    public void RightUp()
    {
        moveRight = false;

    }

    public void JumpDown()
    {
        if(IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, playerJumpHeight);
            src.PlayOneShot(jumpSound);
        }
         
    }

    public void JumpUp()
    {

        if (rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * playerJumpAdjuster);

        }
    }

}

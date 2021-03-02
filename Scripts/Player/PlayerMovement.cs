using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer marioSprite; 
   
    public float Speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;

    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        marioSprite = GetComponent<SpriteRenderer>();


        if (Speed <= 0)
        {
            Speed = 5.0f;
        }
         
        if (jumpForce <=0)
        {
            jumpForce = 100;
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.01f;
        }
        
        if (!groundCheck)
        {
            Debug.Log("Groundcheck does not exist, please set a transform value for groundcheck");
        }
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
           rb.velocity = Vector2.zero;
           rb.AddForce(Vector2.up * jumpForce);
        }

      

        rb.velocity = new Vector2(horizontalInput * Speed, rb.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
        anim.SetBool("isGrounded", !isGrounded);


        if(marioSprite.flipX && horizontalInput > 0 || !marioSprite.flipX && horizontalInput < 0 )
            marioSprite.flipX = !marioSprite.flipX;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Attack();
        }


       /* if (Input.GetKey(KeyCode.UpArrow))
        {
            MarioBrown;
        }
       */
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
    }

    /* void MarioBrown()
    {
        anim.SetTrigger("MarioBrown");
    }
    */
 
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public float maxVelocity = 4.0f;
    public int jumpForce = 250;
    public int jumpCount = 1;
    public int maxJumpCount;
    public string stateName;
    public Animator playerAnim;
    public Rigidbody2D playerRB;
    public Vector3 scale;
    
    // Assign required components at the Awake
    protected virtual void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        scale = this.transform.localScale;
        playerAnim = GetComponent<Animator>();
    }

    // Runs for each frame
    protected virtual void Update()
    {
        Jump();
        Walk();
    }

    // To make character "jump"
    protected void Jump()
    {
        // checks remaining jumps (if it is allowed to jump)
        if (jumpCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.W)) // if the W key pressed
            {
                playerRB.AddForce(Vector2.up * jumpForce); // add force to the "up" direction
                playerAnim.Play(stateName); // play the jump animation of the character
                playerAnim.SetBool("isGrounded",false); // to inform it jumps
                jumpCount--; // decrease by 1 the remaining jumps
            }    
        }
    }
    
    // To detect Collisions
    protected virtual void OnCollisionEnter2D(Collision2D collider)
    {
        // If the collider is "Ground"
        if (collider.gameObject.tag == "Ground")
        {
            jumpCount = maxJumpCount; // It gains all of its jump counts
            playerAnim.SetBool("isGrounded",true); // to inform it is not in the jump state
        }

    }
    
    // To detect Triggers
    protected void OnTriggerEnter2D(Collider2D collider)
    {
        // If the collider is "DeadZone"
        if (collider.gameObject.tag == "DeadZone")
        {
            Destroy(this.gameObject,0.5f);
            playerAnim.SetBool("isDead",true); // to inform it is dead
        }
    }

    // To make character "walk"
    protected void Walk()
    {
        float h = Input.GetAxis("Horizontal"); // get the value of the key, A < 0 ; D > 0
        float force = 0f; // current force
        float velocity = Mathf.Abs(playerRB.velocity.x); // current velocity

        if (h > 0) // if D button pressed
        {
            if (velocity < maxVelocity) // if velocity didn't reach to limit
            {
                force = speed; // make the force value "speed"
                scale.x = 1; // look direction is +x
                this.transform.localScale = scale; // change look rotation of the object
            }
        }
        if (h < 0) // if A button pressed
        {
            if (velocity < maxVelocity) // if velocity didn't reach to limit
            {
                force = -speed; // make the force value -"speed"
                scale.x = -1; // look direction is -x
                this.transform.localScale = scale; // change look rotation of the object
            }
        }

        playerRB.AddForce(new Vector2(force, 0)); // add the force to the object
        playerAnim.SetFloat("speed", Mathf.Abs(h)); // inform animator with the direction
    }
}

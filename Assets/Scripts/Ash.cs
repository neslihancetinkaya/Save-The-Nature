using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ash : Player
{
    // Values for Ash
    private float runForce = 300f;
    private bool forceAdded = false;
    
    // Runs once at Awake 
    protected override void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        scale = this.transform.localScale;
        playerAnim = GetComponent<Animator>();
        maxJumpCount = 1;
        stateName = "Ash_Jump";
    }

    // Runs for each frame
    protected override void Update()
    {
        base.Update(); // Used to call Player's Update
        Run();
    }

    // To make Ash Run
    private void Run()
    {
        // Controls if space button pressed
        // and if the forceAdded before 
        if (Input.GetKeyDown(KeyCode.Space) && !forceAdded)
        {
            playerRB.AddForce(new Vector2(scale.x * runForce, 0)); // Add force in the x direction, scale.x as look direction
            forceAdded = true; // To restrict repeatedly adding force
            playerAnim.SetBool("keyPressed",true); // changes keyPressed value to play run animation
            Invoke("setForceBool", 3); // Invokes the setForceBool method after 3 seconds
        }
        else // If button is not pressed
        {
            playerAnim.SetBool("keyPressed",false); // changes keyPressed value to stop run animation
        }

    }

    // to allow force add
    private void setForceBool()
    {
        forceAdded = false;
    }
}

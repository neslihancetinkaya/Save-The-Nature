using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspen : Player
{
    private BoxCollider2D aspenCollider;
    protected override void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        scale = this.transform.localScale;
        playerAnim = GetComponent<Animator>();
        maxJumpCount = 1;
        stateName = "Aspen_Jump";
        aspenCollider = GetComponent<BoxCollider2D>();
    }

    protected override void Update()
    {
        base.Update();
        Slide(); 
    }
    
    // will change the collider size in this function
    // To make Aspen Slide
    private void Slide()
    {
        if (Input.GetKey(KeyCode.S)) // Check if S button pressed
        {
            playerAnim.SetBool("keyPressed",true); // inform animator key pressed
            aspenCollider.size = new Vector3(0.6989365f,0.7690561f);
            aspenCollider.offset = new Vector3(aspenCollider.offset.x,-0.07f);
            //-0.07
            // x 0.6989365f
            // y 0.7690561f
        }
        if (Input.GetKeyUp(KeyCode.S)) // Check if S button released 
        {
            playerAnim.SetBool("keyPressed",false); // inform animator key released
            aspenCollider.size = new Vector3(0.5676522f,0.9387885f);
            aspenCollider.offset = new Vector3(aspenCollider.offset.x,0.02823359f);
            //0.5676522f
            //0.9387885f
        }
        
    }
}

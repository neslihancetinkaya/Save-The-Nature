using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olivia : Player
{
    protected override void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        scale = this.transform.localScale;
        playerAnim = GetComponent<Animator>();
        maxJumpCount = 2; // To use double jump ability
        stateName = "Olivia_Jump";
    }
}

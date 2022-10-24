using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Maximum Player's speed
    private float maxSpeed = 5f;

    // Start facing right 
    private bool facingRight = true;

    // Reference to Player's RigidBody2D component
    private Rigidbody2D rigidBody;

    // Reference to Player's Animator component
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
       // Get horizontal input
       float hInput = Input.GetAxis("Horizontal"); 

        // Move player's body on the x axis based on horizontal input and maxSpeed
        rigidBody.velocity = new Vector2(hInput * maxSpeed, rigidBody.velocity.y);

        // Pass speed to animator to pick walking or idle animation
        animator.SetFloat("speed", Mathf.Abs(rigidBody.velocity.x));

        // Check player direction and flip if necessary
        if (hInput > 0 && !facingRight)
            FlipHorizontal();
        else if (hInput < 0 && facingRight)
            FlipHorizontal();
    }

    void FlipHorizontal()
    {
        facingRight = !facingRight;
        animator.transform.Rotate(0, 180, 0);
    }
}

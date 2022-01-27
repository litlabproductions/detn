using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;                // Handles player physics
    public float moveSpeed;
    public float jumpForce;

    public Vector2 moveInput;

    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;

    public Animator anim;
    public SpriteRenderer sr;

    public int currentDirection = 1;   // Start in right direction

    // Called ONCE, before the first Update() is called
    void Start(){}

    // Called once per frame (60 times / Sec)
    void Update()
    {
        GetUserInput();
        MovePlayer();
        HandleJumping();
        SetCurrentPosition();
        
        // Flip sprites if direction is 3 (Left)
        if (currentDirection == 3)
            sr.flipX = true;
        else
            sr.flipX = false;

        UpdateAnimator();
    }

    void GetUserInput()
    {        
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
    }

    void MovePlayer()
    {
        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);
    }

    void HandleJumping()
    {
        // Check to see if player is grounded
        RaycastHit hit;

        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround))
            isGrounded = true;
        else
            isGrounded = false;

        if (Input.GetButtonDown("Jump") && isGrounded)
            rb.velocity += new Vector3(0f, jumpForce, 0f);
    }

    void SetCurrentPosition()
    {
        if (Input.GetKeyDown(KeyCode.W))
            currentDirection = 0;
        else if (Input.GetKeyDown(KeyCode.D))
            currentDirection = 1;
        else if (Input.GetKeyDown(KeyCode.S))
            currentDirection = 2;
        else if (Input.GetKeyDown(KeyCode.A))
            currentDirection = 3;
    }

    void UpdateAnimator()
    {
        anim.SetInteger("Direction", currentDirection);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
            anim.SetBool("IsRunning", true);
        else
            anim.SetBool("IsRunning", false);
    }
}
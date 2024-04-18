using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")] //Check if player is on the ground to apply drag (less slippery movement)
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround); //checar con el raycast si hay un piso debajo del jugador
        MyInput();
        SpeedControl();

        //handle drag

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //calculate movement direction

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput; //Walk in the direction youre looking
        rb.AddForce(moveDirection.normalized * moveSpeed *10f, ForceMode.Force);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(moveDirection.normalized * (moveSpeed*7f) * 10f, ForceMode.Force);
        }
    }
    
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if needed

        if(flatVel.magnitude > moveSpeed) //if you go higher than your movement speed
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed; //calculate what max velocity would be
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z); //apply it
        }
    }
    
}

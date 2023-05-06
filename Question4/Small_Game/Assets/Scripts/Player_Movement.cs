using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // SerializeField used to define in unity
    // puplic same but also to be shown in all other scripts
    Rigidbody rb; 
    [SerializeField] float MovementSpeed = 5f;
    [SerializeField] float JumpForce = 5f;

    // control if player hit ground, Transform cause it is need only X, Y, Z
    [SerializeField] Transform GroundCheck;

    // pass a layer of the Ground to check if we hit or not
    [SerializeField] LayerMask ground;


    // add sound of jump
    [SerializeField] AudioSource jumpSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(HorizontalInput * MovementSpeed, rb.velocity.y, VerticalInput * MovementSpeed);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

    }

    // Jump function
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    // check if the player hit the top of the enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            // destroy enemy when I jump on it
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    // check if the player hit the ground
    bool IsGrounded()
    {
        return Physics.CheckSphere(GroundCheck.position, .1f, ground);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] LayerMask groundMask;

    [SerializeField] private float walkSpeed = 500f;
    [SerializeField] private float sprintSpeed = 750f;
    [SerializeField] private float jumpStrength = 690f;

    private float x;
    private float z;
    private bool isJumping;
    private bool isSprinting = false;


    private bool isGrounded;

    private float speed = 0f;

    private void Update()
    {
        getInput();
        jump();
    }

    void FixedUpdate()
    {
        sprint();
        move();
    }

    private void getInput()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        isJumping = Input.GetButtonDown("Jump");

        //if (Input.GetButtonDown("Sprint") && !isSprinting)
        //{
        //    isSprinting = true;
        //}
        //else if (Input.GetButtonUp("Sprint"))
        //{
        //    isSprinting = false;
        //}
    }

    private void move()
    {
        Vector3 move = rb.transform.right * x + rb.transform.forward * z;
        rb.velocity = rb.transform.up * rb.velocity.y + (move * speed * Time.fixedDeltaTime);
    }

    private void jump()
    {
        checkGrounded();
        if (isJumping && isGrounded)
        {
            Vector3 jump = transform.up * jumpStrength;
            rb.AddForce(jump);
        }
    }

    private void checkGrounded()
    {
        float DistanceToTheGround = rb.gameObject.GetComponent<Collider>().bounds.extents.y;
        isGrounded = Physics.Raycast(this.transform.position, Vector3.down, DistanceToTheGround + 0.1f, groundMask);
    }

    private void sprint()
    {
        if (isSprinting)
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }
}

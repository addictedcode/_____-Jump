using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] LayerMask groundMask;

    [SerializeField] private float walkSpeed = 500f;
    [SerializeField] private float airSpeed = 500f;
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
        Vector3 move;
        if (isGrounded)
        {
            move = (rb.transform.right * x + rb.transform.forward * z) * speed * Time.fixedDeltaTime;
        }
        else
        {
            move = (rb.transform.right * x + rb.transform.forward * z) * speed * Time.fixedDeltaTime;
        }
        
        //rb.velocity = rb.transform.up * rb.velocity.y + (move * speed * Time.fixedDeltaTime);
        rb.velocity = (new Vector3(move.x, rb.velocity.y, move.z));
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
        isGrounded = Physics.Raycast(rb.transform.position, Vector3.down, DistanceToTheGround + 0.1f, groundMask);
    }

    private void sprint()
    {
        if (!isGrounded)
        {
            speed = airSpeed;
        }
        else
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
}
//public class FPSMovement : MonoBehaviour
//{
//    [SerializeField] private Rigidbody rb;

//    [SerializeField] LayerMask groundMask;

//    [SerializeField] private float walkSpeed = 10f;
//    [SerializeField] private float sprintSpeed = 20f;
//    [SerializeField] private float jumpStrength = 10f;
//    //[SerializeField] private float fallSpeed = 1.0f;

//    private float x;
//    private float z;
//    private bool isJumping;
//    private bool isSprinting = false;



//    [SerializeField] private bool isGrounded;

//    private float speed = 0f;

//    private void Update()
//    {
//        getInput();
//        jump();
//    }

//    void FixedUpdate()
//    {
//        sprint();
//        move();
//    }

//    private void getInput()
//    {
//        x = Input.GetAxis("Horizontal");
//        z = Input.GetAxis("Vertical");

//        isJumping = Input.GetButtonDown("Jump");
//        //if (Input.GetButtonDown("Sprint") && !isSprinting)
//        //{
//        //    isSprinting = true;
//        //}
//        //else if (Input.GetButtonUp("Sprint"))
//        //{
//        //    isSprinting = false;
//        //}
//    }

//    private void move()
//    {
//        Vector3 move = rb.transform.right * x + rb.transform.forward * z;
//        rb.velocity = (new Vector3(move.x * speed, rb.velocity.y, move.z * speed));
//        //rb.velocity = rb.transform.up * rb.velocity.y + (move * speed * Time.fixedDeltaTime); // richmond code
//    }

//    private void jump()
//    {
//        checkGrounded();
//        if (isJumping && isGrounded)
//        {
//            //rb.velocity = (new Vector3(rb.velocity.x, 0, rb.velocity.z));
//            //rb.velocity += Vector3.up * jumpStrength;
//            Vector3 jump = transform.up * jumpStrength;
//            rb.AddForce(jump);
//        }
//    }

//    private void checkGrounded()
//    {
//        float DistanceToTheGround = rb.gameObject.GetComponent<Collider>().bounds.extents.y;
//        isGrounded = Physics.Raycast(rb.transform.position, Vector3.down, DistanceToTheGround + 0.1f, groundMask);
//    }

//    private void sprint()
//    {
//        if (isSprinting)
//        {
//            speed = sprintSpeed;
//        }
//        else
//        {
//            speed = walkSpeed;
//        }
//    }
//}

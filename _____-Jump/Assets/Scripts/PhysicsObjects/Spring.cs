using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isGrounded;

    [SerializeField] private float springForce = 1000;
    [SerializeField] private float springForceLimit = 2500;

    private void Update()
    {
        checkGrounded();
        if (isGrounded)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
    private void checkGrounded()
    {
        float DistanceToTheGround = rb.gameObject.GetComponent<Collider>().bounds.extents.y;
        isGrounded = Physics.Raycast(rb.transform.position, Vector3.down, DistanceToTheGround - .2f, groundMask);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Parameters param = new Parameters();
            param.PutExtra("springForce", springForce);
            param.PutExtra("springForceLimit", springForceLimit);
            EventBroadcaster.Instance.PostEvent(EventNames.PhysicsEvents.SPRING_IS_TRIGGERED, param);
        }
    }

}

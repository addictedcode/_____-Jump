using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJumping : MonoBehaviour
{
    [SerializeField] private float fallMultiplier = 2.0f;
    [SerializeField] private float lowJumpMultiplier = 2.0f;
    [SerializeField] private float highJumpMultiplier = 1.0f;
    [SerializeField] private Rigidbody rb;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.fixedDeltaTime;        
        }
        else if (rb.velocity.y > 0 && Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (highJumpMultiplier - 1) * Time.fixedDeltaTime;        
        }
    }
}

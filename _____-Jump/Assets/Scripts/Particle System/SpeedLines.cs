using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLines : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ParticleSystem speedLines_Horizontal_ParticleSystem;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject center;
    [SerializeField] private float speedFloor_Horizontal = 10f;

    /*
     what do we want?
     speed lines comes out when the player goes fast
     speed lines go in the direction that the player is speeding at
     speed lines get faster when the player goes faster
     */
    // Update is called once per frame
    void Update()
    {
        float velocityMagnitude;
        velocityMagnitude = rb.velocity.magnitude;
        Vector3 velocity = rb.transform.InverseTransformDirection(rb.velocity);
        var emission = speedLines_Horizontal_ParticleSystem.emission;
        var shape = speedLines_Horizontal_ParticleSystem.shape;
        float angle = 180 * (float)Math.Atan2(velocity.x, velocity.z) / (float)Math.PI;

        if (velocityMagnitude > speedFloor_Horizontal)
        {
            emission.rateOverTime = speedFloor_Horizontal;
        }
        else
        {
            emission.rateOverTime = 0f;
        }

        //speedLines_Horizontal_ParticleSystem.transform.eulerAngles = new Vector3(0, angle * center.transform.rotation.y, 0);

    }
}

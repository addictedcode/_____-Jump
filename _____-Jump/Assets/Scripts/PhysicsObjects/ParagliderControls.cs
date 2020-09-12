using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParagliderControls : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject Camera;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float lowSpeed = 2;
    [SerializeField] private float highSpeed = 8;
    [SerializeField] private float terminalVelocity = -30;
    [SerializeField] private GameObject paragliderPrefab;
    [SerializeField] private GameObject paraglider;

    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(
            EventNames.PhysicsEvents.GROUNDED_IS_TRIGGERED,
            this.groundedTrigger
            );
    }
    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveActionAtObserver(
           EventNames.PhysicsEvents.GROUNDED_IS_TRIGGERED,
           this.groundedTrigger
           );
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            
            if(paraglider == null) paraglider = GameObject.Instantiate(paragliderPrefab, Camera.transform);

            if (Camera.transform.localRotation.eulerAngles.x > 70 &&
            Camera.transform.localRotation.eulerAngles.x <= 91) 
            { // when player is looking down, the paraglider will instead speed up the player's fall speed
                rb.velocity += Vector3.up * Physics.gravity.y * (highSpeed - 1) * Time.fixedDeltaTime;
            }
            else
            {// when player is looking up the paraglider will instead slow down the player's fall speed
                rb.velocity -= Vector3.up * Physics.gravity.y * (lowSpeed - 1) * Time.fixedDeltaTime;
                // terminal falling velocity
                if (rb.velocity.y < -30)
                {
                    rb.velocity = new Vector3(rb.velocity.x, terminalVelocity, rb.velocity.z);
                }
            }
            
        }
        if (!Input.GetKey(KeyCode.Mouse1))
        {
            Destroy(paraglider);
        }
    }


    private void groundedTrigger()
    {
        Destroy(paraglider);
    }
}

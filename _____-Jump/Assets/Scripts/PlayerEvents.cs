using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody rb;
    void Awake()
    {
        EventBroadcaster.Instance.AddObserver(
            EventNames.PhysicsEvents.SPRING_IS_TRIGGERED,
            this.springTrigger
            );
    }
    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveActionAtObserver(
            EventNames.PhysicsEvents.SPRING_IS_TRIGGERED,
            this.springTrigger
            );
    }

    private void springTrigger(Parameters param)
    {

        float springForce = param.GetFloatExtra("springForce", 1000);
        float springForceLimit = param.GetFloatExtra("springForceLimit", 2500);
        float gravityModifier = rb.velocity.y;
        
        if(gravityModifier < -1)
        {
            springForce *= gravityModifier / -9; 
            //the gravity modifier's function is to strengthen the spring force when the player is already falling with a higher y velocity
        }
        if(springForce > springForceLimit)
        {
            springForce = springForceLimit;
        }
        rb.AddForce(Vector3.up * springForce);
    }
}

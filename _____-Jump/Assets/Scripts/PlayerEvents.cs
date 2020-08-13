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

        float springForce = param.GetFloatExtra("springForce", 60);
        float springForceLimit = param.GetFloatExtra("springForceLimit", 250);
        float gravityModifier = rb.velocity.y;

        if(gravityModifier >= 10 || gravityModifier < -10)
        {
            springForce *= -gravityModifier / 10;
        }
        if (springForce > springForceLimit)
        {
            springForce = springForceLimit;
        }
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * springForce);
    }
}

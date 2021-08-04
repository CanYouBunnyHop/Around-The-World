using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGrabSetTrigger : MonoBehaviour
{
    public bool isGrabbed;
    private BoxCollider boxcollider;
    private Rigidbody rb;
    public float minspeed;

    public void Awake()
    {
        
        boxcollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }
    public void GrabObject()
    {
        isGrabbed = true;
        //Component prb;
        // prb = transform.parent.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }
    public void DropObject()
    {
        isGrabbed = false;
        rb.useGravity = true;
    }
    public void FixedUpdate()
    {
        if (isGrabbed ) //&& rb.velocity.magnitude > minspeed)
        {
            boxcollider.isTrigger = true;
        }
        else
        {
            boxcollider.isTrigger = false;
        }
    }
}

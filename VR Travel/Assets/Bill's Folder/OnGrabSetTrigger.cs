using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGrabSetTrigger : MonoBehaviour
{
    public bool isGrabbed;
    private BoxCollider boxcollider;
    private Rigidbody rb;
    public float minspeed;
    public GameObject swingChecker;

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
    public void Update() // boxcollider manager
    {
        SwingCheck sc = swingChecker.GetComponent<SwingCheck>();
        if (isGrabbed && sc.sliceReady)
        {
            boxcollider.enabled = true;
            boxcollider.isTrigger = true;
        }
        else if(isGrabbed && sc.sliceReady == false)
        {
            boxcollider.enabled = false;
        }
        if(!isGrabbed)
        {
            boxcollider.enabled = true;
            boxcollider.isTrigger = false;
        }
    }
}

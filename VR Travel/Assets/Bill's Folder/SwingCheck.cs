using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingCheck : MonoBehaviour
{
  public  bool sliceReady;
  public float delayEnterTime;
  public float delayExitTime;
   public void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
          StartCoroutine(DelayedTriggerEnter());
        }
    }
   public void OnTriggerExit(Collider other)
    {
        StartCoroutine(DelayedTriggerExit());
    }
    IEnumerator DelayedTriggerEnter()
    {
      yield return new WaitForSeconds(delayEnterTime);
      sliceReady = false;
    }
    IEnumerator DelayedTriggerExit()
    {
      yield return new WaitForSeconds(delayExitTime);
      sliceReady = true;
    }


}

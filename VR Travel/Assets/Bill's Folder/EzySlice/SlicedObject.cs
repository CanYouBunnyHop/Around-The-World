using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicedObject : MonoBehaviour
{
    public float delayTime = 1f;

    public void Awake()
    {
        StartCoroutine("CutDelay");
    }

    public IEnumerator CutDelay()
    {
        yield return new WaitForSeconds(delayTime);
        MakeActive();
    }

    public void MakeActive()
    {
        this.gameObject.layer = 9;
    }
}

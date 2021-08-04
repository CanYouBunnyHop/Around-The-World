using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EzySlice;
using UnityEngine.XR.Interaction.Toolkit;

public class Slicer : MonoBehaviour
{
    public Material materialAfterSlice;
    public LayerMask sliceMask;
    public bool isTouched;

    private void Update()
    {
        if (isTouched == true)
        {
            Collider[] newObjectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);

            foreach (Collider objectToBeSliced in newObjectsToBeSliced)
            {
                SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice);

                GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice);
                GameObject lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice);

                upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                lowerHullGameobject.transform.position = objectToBeSliced.transform.position;

                MakeItPhysical(upperHullGameobject);
                MakeItPhysical(lowerHullGameobject);

                MakeItSliceable(upperHullGameobject);
                MakeItSliceable(lowerHullGameobject);

                MakeItGrabable(upperHullGameobject);
                MakeItGrabable(lowerHullGameobject);

                Destroy(objectToBeSliced.gameObject);
            }
        }
    }


    private void MakeItPhysical(GameObject obj)
    {
        obj.layer = 0;
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
        obj.AddComponent<SlicedObject>();
    }
    private void MakeItSliceable(GameObject obj)
    {
        obj.layer = LayerMask.NameToLayer("Sliceable");
    }
    private void MakeItGrabable(GameObject obj)
    {
        obj.AddComponent<XRGrabInteractable>();
    }

    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }


}

using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Knife : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private BoxCollider boxCollider;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        boxCollider =   GetComponent<BoxCollider>();
    }

    private void Start()
    {
        boxCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        var oc = other.GetComponentInParent<ObjectCortable>();
        if (!oc) return;

        oc.cutSelf();
    }
}

using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Ingredient : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }
}

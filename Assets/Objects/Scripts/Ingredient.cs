using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Ingredient : MonoBehaviour
{
    public EIngridient ingridientType;
    public EIngridientState ingridientState;
    private XRGrabInteractable grabInteractable;
    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }
}


public enum EIngridient
{
    None, 
    Seta,
    Mano,
    Ojo,
    Baya,
    Rata
}

public enum EIngridientState
{
    Cocinado = 1<<0,
    Crudo = 1<<1,
}
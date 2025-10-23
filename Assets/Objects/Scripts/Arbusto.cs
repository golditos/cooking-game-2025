using System;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Arbusto : MonoBehaviour
{
    private XRSimpleInteractable simpleInteractable;
    public GameObject bayaModel;
    private Transform _tr;

    private void Awake()
    {
        simpleInteractable = GetComponent<XRSimpleInteractable>();
        _tr = transform;
    }

    private void Start()
    {
        simpleInteractable.selectEntered.AddListener(GetBaya);
    }
    
    private void GetBaya(SelectEnterEventArgs arg0)
    {
        var baya = GameObject.Instantiate(bayaModel, _tr.position, _tr.rotation);
        var grabInteractable = baya.GetComponent<XRGrabInteractable>();

        if (grabInteractable)
        {
            var interactorHand = arg0.interactorObject;
            var manager = grabInteractable.interactionManager;
            
            manager.SelectExit(interactorHand, simpleInteractable);
            manager.SelectEnter(interactorHand,grabInteractable);
        }
    }
}

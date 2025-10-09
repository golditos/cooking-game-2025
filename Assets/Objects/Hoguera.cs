using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Hoguera : MonoBehaviour
{
    public XRSimpleInteractable SimpleInteractable;
    public bool isFireActivated = false;
    public ParticleSystem fireParticles;
    public SphereCollider sphereCollider;

    private void Awake()
    {
        SimpleInteractable = GetComponent<XRSimpleInteractable>();
        fireParticles = GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {
        SimpleInteractable.selectEntered.AddListener(FireActivate);
        sphereCollider.isTrigger = true;
    }

    void FireActivate(SelectEnterEventArgs arg0)
    {
        isFireActivated = !isFireActivated;

        if (fireParticles == null) return;

        if (isFireActivated) fireParticles.Play();
        else fireParticles.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Ingredient")
        {
            
        }
        //ifother.tagname("seta"){
        //    other.transform =(sphereCollider.gameObject.transform.position;}
    }

    private void OnDestroy()
    {
        SimpleInteractable.selectEntered.RemoveListener(FireActivate);
    }
}
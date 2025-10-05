using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Hoguera : MonoBehaviour
{
    public XRSimpleInteractable SimpleInteractable;
    public bool isFireActivated = false;
    public ParticleSystem fireParticles;

    private void Awake()
    {
        SimpleInteractable = GetComponent<XRSimpleInteractable>();
        fireParticles = GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {
        SimpleInteractable.selectEntered.AddListener(FireActivate);
    }

    void FireActivate(SelectEnterEventArgs arg0)
    {
        isFireActivated = !isFireActivated;

        if (fireParticles == null) return;

        if (isFireActivated) fireParticles.Play();
        else fireParticles.Stop();
    }
}
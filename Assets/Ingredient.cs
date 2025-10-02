using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Ingredient : MonoBehaviour
{
    public XRGrabInteractable  grabInteractable;

    private void Start()
    {
        grabInteractable.selectEntered.AddListener(SayHola);
    }

    private static void SayHola(SelectEnterEventArgs arg0)
    {
        print("Hola");
    }
}

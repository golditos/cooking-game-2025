using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Secador : MonoBehaviour
{
    [Header("Configuración")]
    public Transform[] slots;
    public float tiempoSecado = 10f;

    private GameObject[] slotObj;

    void Start()
    {
        slotObj = new GameObject[slots.Length];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != other.transform.root) return;
        if (other.CompareTag("Ingredient_dry")) return;
        if (!other.CompareTag("Ingredient")) return;

        int slotIndex = GetPrimerSlotLibre();
        if (slotIndex == -1) return;

        var grab = other.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grab && grab.isSelected)
            grab.interactionManager.SelectExit(grab.firstInteractorSelecting, grab);

        other.transform.SetParent(slots[slotIndex], false);
        other.transform.localPosition = Vector3.zero;
        other.transform.localRotation = Quaternion.identity;

        slotObj[slotIndex] = other.gameObject;

        var rb = other.GetComponent<Rigidbody>();
        RigidbodyConstraints prevConstraints = RigidbodyConstraints.None;
        if (rb)
        {
            prevConstraints = rb.constraints;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

        StartCoroutine(SecarIngrediente(other.gameObject, grab, rb, prevConstraints, slotIndex));
    }

    private IEnumerator SecarIngrediente(GameObject ingrediente, UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab, Rigidbody rb, RigidbodyConstraints prevConstraints, int slotIndex)
    {
        var rend = ingrediente.GetComponentInChildren<Renderer>();
        if (!rend) yield break;

        rend.material = new Material(rend.material);
        Color c0 = rend.material.color;
        Color c1 = new Color(0.6f, 0.4f, 0.2f);

        float t = 0f;
        while (t < tiempoSecado)
        {
            t += Time.deltaTime;
            float k = Mathf.Clamp01(t / tiempoSecado);
            rend.material.color = Color.Lerp(c0, c1, k);
            yield return null;
        }

        ingrediente.tag = "Ingredient_dry";
        rend.material.color = c1;

        if (rb)
        {
            rb.constraints = prevConstraints;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (grab)
            grab.interactionLayers = InteractionLayerMask.GetMask("Default");


        if (grab)
        {
            grab.selectEntered.AddListener((args) =>
            {
                ingrediente.transform.SetParent(null, true); // 🔥 se saca del slot sí o sí
                slotObj[slotIndex] = null;                   // libera el hueco
            });
        }
    }

    private int GetPrimerSlotLibre()
    {
        for (int i = 0; i < slotObj.Length; i++)
        {
            if (slotObj[i] == null) return i;
        }
        return -1;
    }
}

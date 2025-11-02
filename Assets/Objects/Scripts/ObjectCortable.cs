using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ObjectCortable : MonoBehaviour
{
    public GameObject cuttedObject;
    public void cutSelf()
    {
        var objecto = this.transform.GetChild(0).gameObject;
        var location = objecto.transform.position;
        if (!objecto) return;
        Destroy(objecto);
        
        var nuevo = Instantiate(cuttedObject, transform );
        nuevo.transform.SetSiblingIndex(0);
        nuevo.transform.position = location;
        
        Debug.Log("ObjectCortable cut");
        
        var grab = GetComponent<XRGrabInteractable>();
        if (grab)
        {
            grab.colliders.Clear();
            var newColliders = nuevo.GetComponentsInChildren<Collider>();
            foreach (var col in newColliders) grab.colliders.Add(col);
        }
    }
}

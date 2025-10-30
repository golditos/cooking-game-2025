using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

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

    }
}

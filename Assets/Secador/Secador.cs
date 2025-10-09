using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secador : MonoBehaviour
{
    [Header("Configuración")]
    public Transform[] slots;
    public GameObject secoPrefab; 
    public float tiempoSecado = 10f;
    public int capacidadMax = 4;

    private List<GameObject> ingredientes = new List<GameObject>();
    private bool[] slotOcupado;
    
    
    void Start()
    {
        slotOcupado = new bool[slots.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ingrediente"))
        {
            if (ingredientes.Count < capacidadMax)
            {
                int slotIndex = GetPrimerSlotLibre();
                if (slotIndex != -1) return;
                
                ingredientes.Add(other.gameObject);
                other.gameObject.SetActive(false);
                
                GameObject visual = Instantiate(other.gameObject, slots[slotIndex].position, Quaternion.identity);
                visual.transform.SetParent(slots[slotIndex]);
                slotOcupado[slotIndex] = true;
                
                StartCoroutine(SecarIngrediente(slotIndex, visual));
            }
            else
            {
               print("No queda espaciooooo!");
            }
            
            
        }
        
    }

    private IEnumerator SecarIngrediente(int slotIndex, GameObject visual)
    {
        print("Secando ingrediente!");
        yield return new WaitForSeconds(10);

        Destroy(visual);
        
        GameObject seco = Instantiate(secoPrefab, slots[slotIndex].position, Quaternion.identity);
        seco.transform.SetParent(slots[slotIndex]);
        
        print("Ingrediente secoooo!");
    }

    private int GetPrimerSlotLibre()
    {
        for (int i = 0; i < slotOcupado.Length; i++)
        {
            if (!slotOcupado[i])  return i;
        }

        return -1;
    }
}

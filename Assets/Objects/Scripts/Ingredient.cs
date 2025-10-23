using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Ingredient")]
[Serializable] public class Ingredient : MonoBehaviour
{
    
    public class IngredientAll
    {
        public int Type;
        public int State;

        public IngredientAll(int type, int state)
        {
            Type = type;
            State = state;
        }
    }
    public List<IngredientAll> ingredientsAll = new List<IngredientAll>();
    
    EIngredient Type;
    EIngredientState State;
    public GameObject ingredientPrefab;
    
    private XRGrabInteractable grabInteractable;
    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }
    
}
public enum EIngredient
{
    None = 0, 
    Seta = 1<<0,
    Mano  = 1<<1,
    Ojo   = 1<<2,
    Baya = 1<<3,
    Rata =  1<<4,
}

public enum EIngredientState
{
    None = 0,
    Cocinado = 1<<8,
    Crudo = 1<<9,
    Cortado = 1<<10,
    NoCortado = 1<<11,
}
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Ingredient : MonoBehaviour
{
    public EIngredient ingredientType;
    public EIngredientState ingredientState;
    private XRGrabInteractable grabInteractable;
    private EType type = EType.Ingrediente;
    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    
        var childColliders = transform.GetChild(0).GetComponentsInChildren<Collider>();
        grabInteractable.colliders.Clear();
        foreach (var col in childColliders) grabInteractable.colliders.Add(col);
    }

    public ItemData GetItemData()
    {
        return new ItemData(ingredientType, ingredientState, type);
    }
}


public class ItemData
{
    public EIngredient Ingredient { get; private set; }
    public EIngredientState State { get; private set; }
    public EType Type { get; private set; }

    public ItemData(EIngredient ingredient, EIngredientState state, EType type)
    {
        Type = type;
        Ingredient = ingredient;
        State = state;
    }

    public bool Equals(ItemData other)
    {
        return Ingredient == other.Ingredient && State == other.State;
    }
}

public enum EType
{
    Ingrediente, 
    Receta
}

public enum EIngredient
{
    None, 
    Seta,
    Mano,
    Ojo,
    Baya,
    Rata
}

public enum EIngredientState
{
    Crudo,
    Seco,
    Cortado
}
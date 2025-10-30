using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Ingredient : MonoBehaviour
{
    public List<EIngredient> ingredientType;
    public List<EIngredientState> ingredientState;
    private XRGrabInteractable grabInteractable;
    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }
    public ItemData GetItemData()
    {
        return new ItemData(ingredientType, ingredientState);
    }
}


public class ItemData
{
    public List<EIngredient> Ingredients { get; private set; }
    public List<EIngredientState> States { get; private set; }

    public ItemData(List<EIngredient> ingredients, List<EIngredientState> states)
    {
        Ingredients = new List<EIngredient>(ingredients);
        States = new List<EIngredientState>(states);
    }

    public bool Equals(ItemData other)
    {
        return Ingredients.SequenceEqual(other.Ingredients) &&
               States.SequenceEqual(other.States);
    }
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
    Cocinado,
    Crudo
}
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "RecetaData")]
public class RecetaData : ScriptableObject
{
   
    
    public List<EIngredient> recipeIngredients;
    public List<EIngredientState> recipeIngredientStates;
    public GameObject result;
    
    public bool Contains(List<EIngredient> ingredients)
    {
        var aux = new List<EIngredient>(ingredients);
        foreach (EIngredient ingredient in ingredients)
        {
            if (aux.Contains(ingredient))
            {
                aux.Remove(ingredient);
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    public bool IsSame(List<EIngredient> ingridients) => recipeIngredients.SequenceEqual(ingridients);
    
    
}

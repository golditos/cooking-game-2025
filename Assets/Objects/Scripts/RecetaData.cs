using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "RecetaData")]
public class RecetaData : ScriptableObject
{
    public List<EIngredient> RecipeIngredients = new();
    public List<EIngredientState> RecipeIngredientState = new();
    public GameObject result;

    public bool IsSame(List<EIngredient> ingridients) => RecipeIngredients.SequenceEqual(ingridients);
    
}

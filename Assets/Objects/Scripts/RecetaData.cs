using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "RecetaData")]
public class RecetaData : ScriptableObject
{
    public List<EIngridient> RecipeIngredients = new();
    public GameObject result;

    public bool IsSame(List<EIngridient> ingridients) => RecipeIngredients.SequenceEqual(ingridients);
}

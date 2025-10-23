using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "RecetaData")]
public class RecetaData : ScriptableObject
{
    public class RecepieAll
    {
        public int Type;
        public int State;

        public RecepieAll(int type, int state)
        {
            Type = type;
            State = state;
        }
    }
    
    public List<RecepieAll> recepieall = new List<RecepieAll>();
    
    public List<EIngredient> type = new();
    public List<EIngredientState> state = new();
    public GameObject result;

    public bool IsSame(List<RecepieAll> ingredients) => recepieall.SequenceEqual(ingredients);

    public bool Contains(List<RecepieAll> ingredients)
    {
        var aux = new List<RecepieAll>(recepieall);
        foreach (RecepieAll ingredient in ingredients)
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
    
}

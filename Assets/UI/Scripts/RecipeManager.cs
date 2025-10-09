using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public RecipeUI recipeUI; 
    public Sprite mano, rata, seta, patata; 

    void Start()
    {
        // Ejemplo 1: receta de 3 ingredientes
        recipeUI.ShowRecipe(
            new List<Sprite> { mano, rata, seta }, 
            patata                                           
        );

        // Si más adelante quieres probar otra receta, podrías hacerlo así:
        // recipeUI.ShowRecipe(new List<Sprite> { manzana, pera, platano, pera }, smoothie);
    }
}
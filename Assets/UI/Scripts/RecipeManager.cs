using UnityEngine;
using UnityEngine.Events;

public class RecipeManager : MonoBehaviour
{
    [Header("Referencias")]
    public RecipeUI recipeUI;

    [Header("Recetas disponibles")]
    public RecetaData[] allRecipes;

    [Header("Eventos")]
    public UnityEvent<RecetaData> OnRecipeChanged;

    private RecetaData current;

    void Start()
    {
        NextRandomRecipe();
    }

    public void CompleteCurrentRecipe()
    {
        NextRandomRecipe();
    }

    private void NextRandomRecipe()
    {
        if (allRecipes == null || allRecipes.Length == 0) return;

        RecetaData next = allRecipes[Random.Range(0, allRecipes.Length)];
        if (allRecipes.Length > 1)
        {
            int guard = 10;
            while (next == current && guard-- > 0)
                next = allRecipes[Random.Range(0, allRecipes.Length)];
        }

        current = next;
        Debug.Log("Nuevo receta"+ current);
        recipeUI.ShowRecipe(current);
        OnRecipeChanged?.Invoke(current);
    }

    public RecetaData GetCurrentRecipe() => current;
}
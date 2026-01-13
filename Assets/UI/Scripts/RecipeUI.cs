using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeUI : MonoBehaviour
{
    [Header("Referencias")]
    public Transform ingredientsContainer;
    public Image resultImage;

    [Header("Prefabs")]
    public GameObject ingredientImagePrefab;
    public GameObject plusTextPrefab;
    public GameObject equalTextPrefab;

    [Header("Sprites de Ingredientes")]
    public Sprite setaSprite;
    public Sprite manoSprite;
    public Sprite ojoSprite;
    public Sprite bayaSprite;
    public Sprite rataSprite;
    public Sprite defaultSprite;

    private List<Image> currentIngredientImages = new List<Image>();

    public void ShowRecipe(RecetaData receta)
    
    {
        Debug.Log("🧾 Mostrando receta: " + (receta != null ? receta.name : "NULL"));
        if (receta == null) return;

        foreach (Transform child in ingredientsContainer)
            Destroy(child.gameObject);
        currentIngredientImages.Clear();

        for (int i = 0; i < receta.recipeIngredients.Count; i++)
        {
            GameObject imgObj = Instantiate(ingredientImagePrefab, ingredientsContainer);
            Image img = imgObj.GetComponent<Image>();
            img.sprite = GetIngredientSprite(receta.recipeIngredients[i]);
            currentIngredientImages.Add(img);

            if (i < receta.recipeIngredients.Count - 1)
                Instantiate(plusTextPrefab, ingredientsContainer);
        }

        Instantiate(equalTextPrefab, ingredientsContainer);

        if (resultImage != null && receta.result != null)
        {
            SpriteRenderer rend = receta.result.GetComponentInChildren<SpriteRenderer>();
            if (rend != null)
                resultImage.sprite = rend.sprite;
        }
    }

    private Sprite GetIngredientSprite(EIngredient ingredient)
    {
        switch (ingredient)
        {
            case EIngredient.Seta: return setaSprite;
            case EIngredient.Mano: return manoSprite;
            case EIngredient.Ojo: return ojoSprite;
            case EIngredient.Baya: return bayaSprite;
            case EIngredient.Rata: return rataSprite;
            default: return defaultSprite;
        }
    }

    public void MarkIngredientCooked(int index)
    {
        if (index >= 0 && index < currentIngredientImages.Count)
        {
            var img = currentIngredientImages[index];
            img.color = Color.green;
        }
    }
}

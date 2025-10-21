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
    
    private List<Image> currentIngredientImages = new List<Image>();
    public void ShowRecipe(List<Sprite> ingredients, Sprite resultSprite)
    {
        foreach (Transform child in ingredientsContainer)
            Destroy(child.gameObject);
        currentIngredientImages.Clear();


        for (int i = 0; i < ingredients.Count; i++)
        {

            GameObject imgObj = Instantiate(ingredientImagePrefab, ingredientsContainer);
            imgObj.GetComponent<Image>().sprite = ingredients[i];

            if (i < ingredients.Count - 1)
            {
                Instantiate(plusTextPrefab, ingredientsContainer);
            }
        }

        Instantiate(equalTextPrefab, ingredientsContainer);
            resultImage.sprite = resultSprite;
            
    }

    public void MarkIngredientCooked(int index)
    {
        if (index >= 0 && index < currentIngredientImages.Count)
        {
            var img = currentIngredientImages[index];
            img.color = Color.green;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

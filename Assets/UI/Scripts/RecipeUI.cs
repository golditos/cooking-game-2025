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

    public void ShowRecipe(List<Sprite> ingredients, Sprite resultSprite)
    {
        foreach (Transform child in ingredientsContainer)
            Destroy(child.gameObject);

        foreach (Sprite ingredient in ingredients)
        {
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
            
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Objects
{
    public class Hoguera : MonoBehaviour
    {
        public XRSimpleInteractable SimpleInteractable;
        public bool isFireActivated = false;
        public ParticleSystem fireParticles;
        public SphereCollider sphereCollider;
        public GameObject sopa;
        
        private List<EIngredient> _ingredients = new();

        private void Awake()
        {
            SimpleInteractable = GetComponent<XRSimpleInteractable>();
            fireParticles = GetComponentInChildren<ParticleSystem>();
        }

        private void Start()
        {
            SimpleInteractable.selectEntered.AddListener(FireActivate);
            sphereCollider.isTrigger = true;
            sopa.SetActive(false);
        }

        void FireActivate(SelectEnterEventArgs arg0)
        {
            isFireActivated = !isFireActivated;

            if (fireParticles == null) return;

            if (isFireActivated) fireParticles.Play();
            else fireParticles.Stop();
            
            if (isFireActivated) CheckRecipes();

        }
        
        private void OnTriggerEnter(Collider other)
        {
            Ingredient ingredient;
            if (!other.TryGetComponent(out ingredient))
            {
                Debug.Log("Collision with Pot is not Ingridient");
                return;
            }

            Debug.Log($"Collision with Pot is {ingredient.ingredientType} & {ingredient.ingredientState}");
            _ingredients.Add(ingredient.ingredientType);
            
            var grab = other.GetComponent<XRGrabInteractable>();
            if (grab && grab.isSelected)
            {
                grab.interactionManager.SelectExit(grab.firstInteractorSelecting, grab);
            }
            
            Destroy(other.gameObject);
            sopa.SetActive(true);

            if (isFireActivated) CheckRecipes();

        }

        private void CheckRecipes()
        {
            var Recipes = GameManager.instance?.recipes;
            if (Recipes == null) return;
            
            List<RecetaData> validRecipes = new();
            
            Debug.Log("Recipes: " + Recipes);
            foreach (var recipe in Recipes)
            {
                if (recipe.Contains(_ingredients))
                {
                    validRecipes.Add(recipe);
                }
            }

            if (validRecipes.Count == 0)
            {
                _ingredients.Clear();
                print("No hay recipes con estos ingredientes");
                return;
            }
            
            foreach (var recipe in validRecipes)
            {
                bool isRecipeDone = recipe.IsSame(_ingredients);
                if (isRecipeDone)
                {
                    Debug.Log(recipe.name + " Is done with the result: " + recipe.result.name);
                    Instantiate(recipe.result, transform.position + Vector3.up, Quaternion.identity);
                    _ingredients.Clear();
                    sopa.SetActive(false);
                }
            }
        }

        private void OnDestroy()
        {
            SimpleInteractable.selectEntered.RemoveListener(FireActivate);
        }
    }
}
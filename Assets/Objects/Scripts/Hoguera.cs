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

        private List<EIngridient> _ingridients = new();

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
        }

        private void OnTriggerEnter(Collider other)
        {
            Ingredient ingredient;
            if (!other.TryGetComponent(out ingredient))
            {
                Debug.Log("Collision with Pot is not Ingridient");
                return;
            }
            
            Debug.Log($"Collision with Pot is {ingredient.ingridientType}");
        
            _ingridients.Add(ingredient.ingridientType);
            
            var grab = other.GetComponent<XRGrabInteractable>();
            if (grab && grab.isSelected)
            {
                grab.interactionManager.SelectExit(grab.firstInteractorSelecting, grab);
            }
            
            Destroy(other.gameObject);
            sopa.SetActive(true);

            CheckRecipes();
        }

        private void CheckRecipes()
        {
            var Recipes = GameManager.instance?.recipes;
            foreach (var recipe in Recipes)
            {
                bool isRecipeDone = recipe.IsSame(_ingridients);
                if (isRecipeDone)
                {
                    Instantiate(recipe.result, transform.position + Vector3.up, Quaternion.identity);
                }
            }
        }

        private void OnDestroy()
        {
            SimpleInteractable.selectEntered.RemoveListener(FireActivate);
        }
    }
}
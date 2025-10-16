using System;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class GameManager  : MonoBehaviour
    {
        public static GameManager instance { get; private set; }

        public List<RecetaData> recipes = new();
        
        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
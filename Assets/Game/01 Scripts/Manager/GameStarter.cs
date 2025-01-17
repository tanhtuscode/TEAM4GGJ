using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game._01_Scripts.Manager
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] public GameObject managers;

        private void Awake()
        {
            if (managers == null)
            {
                Debug.LogError("Managers is null");
                return;
            }
            Instantiate(managers);
            
        }

        private void Start()
        {
            Debug.Log("GameStarter is started");
        }

        
    }
}

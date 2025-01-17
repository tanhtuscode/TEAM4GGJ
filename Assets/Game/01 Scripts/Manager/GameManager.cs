using System;
using UnityEngine;

namespace Game._01_Scripts.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        private void OnEnable()
        {
            Debug.Log("GameManager is enabled");
        }
    }
}

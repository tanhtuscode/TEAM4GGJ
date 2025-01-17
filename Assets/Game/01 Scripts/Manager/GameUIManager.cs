using TMPro;
using UnityEngine;

namespace Game._01_Scripts.Manager
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text diceValueText;
        private void OnEnable()
        {
            Init();
        }

        public void Init()
        {
            diceValueText.text = "";
            ActionEvent.OnDiceRoll += SetDiceValue;
        }
        
        public void SetDiceValue(int value)
        {
           diceValueText.text = value.ToString();
        }
    }
}

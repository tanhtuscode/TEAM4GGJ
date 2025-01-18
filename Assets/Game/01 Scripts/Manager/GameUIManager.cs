using TMPro;
using UnityEngine;

namespace Game._01_Scripts.Manager
{
    public class GameUIManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text diceValueText;
        [SerializeField] private float displayDuration = 2f; // Time in seconds before the value disappears

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
            StartCoroutine(ClearDiceValueAfterDelay());
        }

        private System.Collections.IEnumerator ClearDiceValueAfterDelay()
        {
            yield return new WaitForSeconds(displayDuration);
            diceValueText.text = "";
        }

        private void OnDisable()
        {
            // Unsubscribe to avoid memory leaks
            ActionEvent.OnDiceRoll -= SetDiceValue;
        }
    }
}
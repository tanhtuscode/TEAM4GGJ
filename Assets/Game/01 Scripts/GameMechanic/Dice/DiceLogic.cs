using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game._01_Scripts.GameMechanic.Dice
{
    [Serializable]
    public class Dice
    {
        public int value;
        public Sprite sprite;
    }

    public class DiceLogic : MonoBehaviour
    {
        [SerializeField] private Dice[] dices;         // Array of dice
        [SerializeField] private Image spriteRenderer; // UI Image for displaying dice
        [SerializeField] private Button rollButton;    // Reference to the roll button

        private RectTransform spriteTransform;

        private void Start()
        {
            // Cache the RectTransform of the sprite renderer
            spriteTransform = spriteRenderer.GetComponent<RectTransform>();

            // Attach the RollDiceAction to the button click
            if (rollButton != null)
            {
                rollButton.onClick.AddListener(RollDiceAction);
            }
        }

        public void RollDiceAction()
        {
            StartCoroutine(RollDice());
        }

        public IEnumerator RollDice()
        {
            float totalDuration = 4f; // Total duration of animation
            float elapsedTime = 0f;  // Time elapsed
            float minInterval = 0.05f; // Minimum interval for the final slow-down
            float startInterval = 0.2f; // Starting interval between frame changes

            // Select the final dice value before starting the animation
            int finalDice = UnityEngine.Random.Range(0, dices.Length);

            while (elapsedTime < totalDuration)
            {
                int randomDice;

                // If the remaining time is less than a threshold, start approaching the final value
                if (totalDuration - elapsedTime <= 0.5f)
                {
                    randomDice = finalDice; // Focus on the final dice value
                }
                else
                {
                    randomDice = UnityEngine.Random.Range(0, dices.Length);
                }

                spriteRenderer.sprite = dices[randomDice].sprite;

                // Apply a random rotation to the dice image
                float randomRotation = UnityEngine.Random.Range(0f, 360f);
                spriteTransform.rotation = Quaternion.Euler(0f, 0f, randomRotation);

                // Calculate the interval dynamically to slow down the animation
                float interval = Mathf.Lerp(startInterval, minInterval, elapsedTime / totalDuration);
                elapsedTime += interval;

                yield return new WaitForSeconds(interval);
            }

            // Ensure the dice stops at the preselected final value
            spriteRenderer.sprite = dices[finalDice].sprite;

            // Reset rotation to 0 degrees at the end
            spriteTransform.rotation = Quaternion.identity;
        }
    }
}

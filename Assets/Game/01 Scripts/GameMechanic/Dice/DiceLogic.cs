using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Game._01_Scripts.GameMechanic.Dice
{
    [Serializable]
    public class Dice
    {
        public int value;  // Value of the dice face (1 to 6)
        public Sprite sprite;  // Sprite representing the dice face
    }

    public class DiceLogic : MonoBehaviour
    {
        [SerializeField] private Dice[] dices;         // Array of dice (1-6, each repeated 4 times)
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
            float totalDuration = 4f;  // Total duration of animation
            float elapsedTime = 0f;   // Time elapsed
            float minInterval = 0.05f;  // Minimum interval for the final slow-down
            float startInterval = 0.2f;  // Starting interval between frame changes

            // Select the final dice value (1 to 6)
            int finalValue = UnityEngine.Random.Range(1, 7);

            // Select a random sprite for the final value
            int finalSpriteIndex = UnityEngine.Random.Range(0, 4);
            Dice finalDice = dices[(finalValue - 1) * 4 + finalSpriteIndex];

            while (elapsedTime < totalDuration)
            {
                Dice randomDice;

                // If the remaining time is less than a threshold, start approaching the final value
                if (totalDuration - elapsedTime <= 0.5f)
                {
                    randomDice = finalDice; // Focus on the final dice value
                }
                else
                {
                    // Randomly pick a dice value and its sprite
                    int randomValue = UnityEngine.Random.Range(1, 7);
                    int randomSpriteIndex = UnityEngine.Random.Range(0, 4);
                    randomDice = dices[(randomValue - 1) * 4 + randomSpriteIndex];
                }

                spriteRenderer.sprite = randomDice.sprite;

                // Apply a random rotation to the dice image
                float randomRotation = UnityEngine.Random.Range(0f, 360f);
                spriteTransform.rotation = Quaternion.Euler(0f, 0f, randomRotation);

                // Calculate the interval dynamically to slow down the animation
                float interval = Mathf.Lerp(startInterval, minInterval, elapsedTime / totalDuration);
                elapsedTime += interval;

                yield return new WaitForSeconds(interval);
            }

            // Ensure the dice stops at the preselected final value
            spriteRenderer.sprite = finalDice.sprite;

            // Reset rotation to 0 degrees at the end
            spriteTransform.rotation = Quaternion.identity;

            // Trigger an event with the final dice value
            ActionEvent.OnDiceRoll?.Invoke(finalValue);
        }
    }
}

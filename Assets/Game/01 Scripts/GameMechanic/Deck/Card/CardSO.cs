using UnityEngine;

namespace Game._01_Scripts.GameMechanic.Deck.Card
{
    public enum CardType { Normal, Special }

    [CreateAssetMenu(fileName = "NewCard", menuName = "Game/Card")]
    public class CardSO : ScriptableObject
    {
        public CardType CardType;   // Normal or Special
        public string Name;         // Card name (e.g., "Ace of Spades")
        public Sprite Sprite;       // Card sprite
        public int Value;           // Value of normal cards (negative for black, positive for red)
        public bool IsUsed;         // Whether the card is already used
        public string SpecialEvent; // Special event for special cards (leave empty for normal cards)
    }
}
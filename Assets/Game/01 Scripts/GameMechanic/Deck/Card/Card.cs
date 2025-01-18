using UnityEngine;

namespace Game._01_Scripts.GameMechanic.Deck.Card
{
    public enum CardType
    {
        Normal,
        Special
    }
    public class Card : MonoBehaviour
    {
        public CardData CardData;
        public void SetCardData(CardData cardData)
        {
            CardData = cardData;
        }
        
    }
}
using UnityEngine;

namespace Game._01_Scripts.GameMechanic.Deck.Card
{
    public struct CardData
    {
        public CardType CardType;
        public int CardValue;
        public string CardName;
        public string CardDescription;
        public Sprite CardImage;
        
        public CardData(CardType cardType, int cardValue, string cardName, string cardDescription, Sprite cardImage)
        {
            CardType = cardType;
            CardValue = cardValue;
            CardName = cardName;
            CardDescription = cardDescription;
            CardImage = cardImage;
        }}
}
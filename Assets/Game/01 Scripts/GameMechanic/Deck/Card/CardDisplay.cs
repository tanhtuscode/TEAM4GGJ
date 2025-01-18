using Game._01_Scripts.GameMechanic.Deck.Card;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private Image cardImage;
    [SerializeField] private CardType cardType;
    public void SetCard(CardSO card)
    {
        cardImage.sprite = card.Sprite;
        cardType = card.CardType;
    }
}
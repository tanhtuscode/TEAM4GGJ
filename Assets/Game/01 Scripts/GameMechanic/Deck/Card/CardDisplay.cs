using Game._01_Scripts.GameMechanic.Deck.Card;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private Image cardImage;
    [SerializeField] private TMP_Text cardName;

    public void SetCard(CardSO card)
    {
        cardImage.sprite = card.Sprite;
        cardName.text = card.Name;
    }
}
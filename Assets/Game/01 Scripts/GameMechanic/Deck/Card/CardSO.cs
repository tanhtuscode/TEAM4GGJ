using Game._01_Scripts.GameMechanic.Deck.Card;
using UnityEngine;

[CreateAssetMenu(fileName = "CardSO", menuName = "Scriptable Objects/CardSO")]
public class CardSO : ScriptableObject
{
    public CardType CardType;
    public int CardValue;
    public string CardName;
    public string CardDescription;
    public Sprite CardImage;
    
    public CardData GetCardData()
    {
        return new CardData(CardType, CardValue, CardName, CardDescription, CardImage);
    }
}

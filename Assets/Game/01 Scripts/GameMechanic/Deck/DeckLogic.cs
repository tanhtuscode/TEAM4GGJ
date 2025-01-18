using Game._01_Scripts.GameMechanic.Deck.Card;
using UnityEngine;

public class DeckLogic : MonoBehaviour
{
    [SerializeField] private CardSO[] _cardSOs;
    
    public CardSO GetRandomCardSO()
    {
        return _cardSOs[Random.Range(0, _cardSOs.Length)];
    }
    
    public CardSO GetCardSO(CardType cardType)
    {
        foreach (var cardSO in _cardSOs)
        {
            if (cardSO.CardType == cardType)
            {
                return cardSO;
            }
        }

        return null;
    }
    
    
}

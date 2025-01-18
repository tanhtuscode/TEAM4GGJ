using Game._01_Scripts.GameMechanic.Deck.Card;
using UnityEngine;
using System.Collections.Generic;

public class DeckLogic : MonoBehaviour
{
    [SerializeField] private CardSO[] cardSOs; // The complete deck of cards
    private List<CardSO> deckPool;            // The current pool of available cards

    [SerializeField] private Transform cardSpawnPoint; // Position where the card will move to
    [SerializeField] private GameObject cardPrefab;    // Prefab for displaying the card

    private void Awake()
    {
        InitializeDeck();
    }

    private void InitializeDeck()
    {
        // Initialize the deck pool with all cards that are not used
        deckPool = new List<CardSO>();
        foreach (var card in cardSOs)
        {
            card.IsUsed = false;
            deckPool.Add(card);
        }
    }

    public void DrawRandomCard()
    {
        if (deckPool.Count == 0)
        {
            Debug.LogWarning("The deck is empty!");
            return;
        }

        // Get a random card
        int randomIndex = Random.Range(0, deckPool.Count);
        CardSO drawnCard = deckPool[randomIndex];

        // Mark as used and remove from the pool
        drawnCard.IsUsed = true;
        deckPool.RemoveAt(randomIndex);

        // Display the card
        DisplayCard(drawnCard);
    }

    private void DisplayCard(CardSO card)
    {
        // Instantiate a card UI object at the spawn point
        GameObject cardObject = Instantiate(cardPrefab, cardSpawnPoint.position, Quaternion.identity);
        CardDisplay cardDisplay = cardObject.GetComponent<CardDisplay>();
        cardDisplay.transform.SetParent(cardSpawnPoint, false);
        if (cardDisplay != null)
        {
            cardDisplay.SetCard(card);
        }
    }
}
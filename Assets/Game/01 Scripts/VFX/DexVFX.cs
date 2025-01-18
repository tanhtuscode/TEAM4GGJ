using UnityEngine;
using UnityEngine.EventSystems;
using PrimeTween;

public class DexVFX : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // The list for cards that use for VFX only
    [SerializeField] private GameObject[] cardDexVFX;
    [SerializeField] private float hoverHeight = 1f; // The height the card moves up
    [SerializeField] private float hoverDuration = 0.5f; // Duration of the hover animation

    private Vector3 originalPosition;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (cardDexVFX.Length == 0) return;

        // Get the last card in the list
        GameObject lastCard = cardDexVFX[cardDexVFX.Length - 1];

        // Save the original position
        originalPosition = lastCard.transform.position;

        // Move the card up
        Vector3 targetPosition = originalPosition + new Vector3(0, hoverHeight, 0);
        Tween.Position(lastCard.transform, targetPosition, hoverDuration, Ease.InOutSine);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (cardDexVFX.Length == 0) return;

        // Get the last card in the list
        GameObject lastCard = cardDexVFX[cardDexVFX.Length - 1];

        // Move the card back to its original position
        Tween.Position(lastCard.transform, originalPosition, hoverDuration, Ease.InOutSine);
    }
}
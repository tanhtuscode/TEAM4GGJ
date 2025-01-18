using UnityEngine;
using UnityEngine.EventSystems;
using PrimeTween;

public class DiceHoverVFX : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float scaleMultiplier = 1.2f; // Amount to scale up
    [SerializeField] private float scaleDuration = 0.5f;  // Duration of the scaling animation
    private Vector3 originalScale;

    private void Awake()
    {
        // Store the original scale of the dice
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Scale the dice up
        Vector3 targetScale = originalScale * scaleMultiplier;
        Tween.LocalScale(transform, targetScale, scaleDuration, Ease.InOutSine);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Scale the dice back to its original size
        Tween.LocalScale(transform, originalScale, scaleDuration, Ease.InOutSine);
    }
}
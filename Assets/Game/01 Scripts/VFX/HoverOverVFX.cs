using UnityEngine;
using UnityEngine.EventSystems;
using PrimeTween;

public class HoverOverVFX : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private RectTransform targetRect;  // The RectTransform to scale
    [SerializeField] private float scaleMultiplier = 1.2f; // Scale factor
    [SerializeField] private float scaleDuration = 0.5f;  // Duration of the scaling animation
    private Vector3 originalScale;

    private void Awake()
    {
        // Ensure a RectTransform is assigned
        if (targetRect == null)
        {
            Debug.LogError("No RectTransform assigned to HoverOverVFX script!", this);
            return;
        }

        // Store the original scale of the RectTransform
        originalScale = targetRect.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Scale the RectTransform up
        Vector3 targetScale = originalScale * scaleMultiplier;
        Tween.LocalScale(targetRect, targetScale, scaleDuration, Ease.InOutSine);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Scale the RectTransform back to its original size
        Tween.LocalScale(targetRect, originalScale, scaleDuration, Ease.InOutSine);
    }
}
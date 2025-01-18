using UnityEngine;
using PrimeTween;

public class ScaleVFX : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private bool scaleOnAwake = true;
    [SerializeField] private float scaleAmount = 0.5f; // Additional scale value
    [SerializeField] private float scaleDuration = 1f; // Duration of scale up/down
    [SerializeField] private bool loop = false; // Whether the scaling effect should loop
    [SerializeField] private float delayBetweenCycles = 0.5f; // Delay between cycles if loop is enabled
    [SerializeField] private Vector3 originalScale;

    private void Awake()
    {
        if (rectTransform == null)
        {
            Debug.LogError("RectTransform is not assigned!", this);
            return;
        }

        originalScale = rectTransform.localScale;

        if (scaleOnAwake)
        {
            ScaleRectTransform();
        }
    }
    
    public void SetOriginalScale(float newScale)
    {
        // Ensure newScale is applied uniformly to all axes
        Vector3 additionalScale = new Vector3(newScale, newScale, newScale);

        // Update the original scale
        originalScale += additionalScale;

        // Apply the new original scale to the RectTransform immediately
        rectTransform.localScale = originalScale;

        Debug.Log($"Original scale updated. Added: {newScale} to each axis. New scale: {originalScale}");
    }

    public void ScaleRectTransform()
    {
        if (rectTransform == null)
        {
            Debug.LogError("RectTransform is not assigned!", this);
            return;
        }

        // Get the current scale as the base for calculations
        originalScale = rectTransform.localScale;
        Vector3 targetScale = originalScale + new Vector3(scaleAmount, scaleAmount, 0);

        if (loop)
        {
            // Looping effect with delay
            void PingPongWithDelay()
            {
                Sequence.Create()
                    .Chain(Tween.LocalScale(rectTransform, targetScale, scaleDuration))
                    .Chain(Tween.Delay(delayBetweenCycles)) // Add delay before scaling back
                    .Chain(Tween.LocalScale(rectTransform, originalScale, scaleDuration))
                    .Chain(Tween.Delay(delayBetweenCycles)) // Add delay before restarting
                    .OnComplete(PingPongWithDelay); // Restart the loop
            }
            PingPongWithDelay();
        }
        else
        {
            // One-time scaling animation
            Sequence.Create()
                .Chain(Tween.LocalScale(rectTransform, targetScale, scaleDuration))
                .Chain(Tween.LocalScale(rectTransform, originalScale, scaleDuration));
        }
    }

    private void OnValidate()
    {
        // Ensure valid values are set in the Inspector
        if (scaleAmount < 0)
        {
            scaleAmount = 0f;
            Debug.LogWarning("ScaleAmount must be non-negative. Resetting to 0.");
        }

        if (scaleDuration <= 0)
        {
            scaleDuration = 0.1f;
            Debug.LogWarning("ScaleDuration must be greater than 0. Resetting to 0.1.");
        }

        if (delayBetweenCycles < 0)
        {
            delayBetweenCycles = 0f;
            Debug.LogWarning("DelayBetweenCycles must be non-negative. Resetting to 0.");
        }
    }
}

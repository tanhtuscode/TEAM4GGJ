using UnityEngine;

public class TestBubble : MonoBehaviour
{
    public void OnChangeValueBubble(int value)
    {
        ActionEvent.OnChangeValueBubble?.Invoke(value);
    }

    public void OnChangeValueCapacity(int value)
    {
        ActionEvent.OnChangeValueCapacity?.Invoke(value);
    }
}
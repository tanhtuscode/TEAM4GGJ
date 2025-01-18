using System;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private int capacity = 0;
    private int currentValue = 0;
    public EBubbleState state { get; set; }
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        ActionEvent.OnChangeValueBubble += InjectionToBubble;
        ActionEvent.OnChangeValueCapacity += ChangeCapacity;
    }

    private void InjectionToBubble(int value)
    {
        this.currentValue += value;
        Debug.Log("Bubble: "+this.currentValue);
        CheckBubbleState();
    }

    private void ChangeCapacity(int value)
    {
        this.capacity += value;
        Debug.Log("Capacity: " + this.capacity);
        CheckBubbleState();
    }

    private void CheckBubbleState()
    {
        if (this.currentValue > this.capacity)
        {
            state = EBubbleState.EXPLOSIVE;
            Debug.Log("BOOMMM!!!");
        }
        else
        {
            state = EBubbleState.NORMAL;  
        }
    }
}
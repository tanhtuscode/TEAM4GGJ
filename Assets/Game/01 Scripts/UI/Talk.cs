using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    [SerializeField] private Text txtTalk;

    private void OnEnable()
    {
        ActionEvent.OnTalk += ShowTalk;
    }

    private IEnumerator Display(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            txtTalk.text += text[i];
            yield return new WaitForSecondsRealtime(0.25f);
        }
    }

    public void ShowTalk(string text)
    {
        StartCoroutine(Display(text));
    }
}
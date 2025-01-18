using System;
using UnityEngine;

public enum ETypeCursor
{
    DEFAULT,
    HOVER
}
public class CursorKanri : MonoBehaviour
{
    private static CursorKanri _instance;
    public static CursorKanri Instance => _instance;
    private void Awake()
    {
        _instance = this;
    }
    
    [SerializeField] private Texture2D[] cursorTexture = new Texture2D[2];

    public void ChangeCursor(ETypeCursor type)
    {
        var texture = cursorTexture[(int)type];
        Cursor.SetCursor(texture,Vector2.zero,CursorMode.Auto);
    }
}

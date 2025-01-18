using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeCursorOnMouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        CursorKanri.Instance.ChangeCursor(ETypeCursor.HOVER);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CursorKanri.Instance.ChangeCursor(ETypeCursor.DEFAULT);
    }
}

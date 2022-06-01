using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    public Action onLeftClick;
    public Action onRightClick;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            onRightClick();
        }
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            onLeftClick();
        }
    }
}

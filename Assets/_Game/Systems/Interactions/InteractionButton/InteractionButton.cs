using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionButton : MonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    public event Action OnClick;
    public event Action OnRelease;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnRelease?.Invoke();
    }
}

using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] protected RectTransform uiRectTransform;
    [SerializeField] protected RectTransform raycastBlock;

    private Vector2 _initialPosition;

    private void Awake()
    {
        _initialPosition = uiRectTransform.transform.position;
    }


    public void OpenUI()
    {
        raycastBlock.gameObject.SetActive(true);
        
        uiRectTransform.DOMoveY(_initialPosition.y, 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            raycastBlock.gameObject.SetActive(false);
        });
    }
    
    public void CloseUI()
    {
        raycastBlock.gameObject.SetActive(true);
        
        uiRectTransform.DOMoveY(_initialPosition.y - uiRectTransform.rect.height, 0.3f).SetEase(Ease.InBack).OnComplete(() =>
        {
            
        });
    }

}
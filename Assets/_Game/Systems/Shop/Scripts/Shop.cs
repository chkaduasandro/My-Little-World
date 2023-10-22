using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private InteractionButton interactionButton;
    [SerializeField] private Transform interactionMenuHolder;
    
    // Hardcoded shop items, Remake to scriptable object may be?;
    [SerializeField] private List<ItemData> itemDatas;

    private void Start()
    {
        interactionButton.OnClick += () => {UIManager.Instance.OpenShopMenu(itemDatas);};
    }


    
    private void OpenInteraction()
    {
        interactionMenuHolder.localScale = Vector3.zero;
        interactionMenuHolder.gameObject.SetActive(true);
        interactionMenuHolder.DOScale(Vector3.one, 0.4f).SetEase(Ease.OutBack);
    }

    private void CloseInteraction()
    {
        interactionMenuHolder.DOScale(Vector3.zero, 0.4f).SetEase(Ease.InBack).OnComplete(() =>
        {
            interactionMenuHolder.gameObject.SetActive(false);
        });
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.Tags.Player))
        {
            OpenInteraction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Constants.Tags.Player))
        {
            CloseInteraction();
        }
    }
}

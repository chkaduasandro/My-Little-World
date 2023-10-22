using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private InteractionButton interactionButton;
    [SerializeField] private Transform interactionMenuHolder;

    // Hardcoded shop items, Remake to scriptable object may be?;
    [SerializeField] public List<ItemData> itemDatas;

    private bool _isInteractable;

    private void Start()
    {
        _isInteractable = false;
        interactionButton.OnClick += () => { UIManager.Instance.OpenShopMenu(this, itemDatas); };
        
        interactionMenuHolder.gameObject.SetActive(false);
    }

    public void AddItem(ItemData itemData)
    {
        itemDatas.Add(itemData);
    }

    public void RemoveItem(ItemData itemData)
    {
        if (!itemDatas.Contains(itemData))
        {
            Debug.Log($"Shop does not contain item {itemData}");
            return;
        }
        itemDatas.Remove(itemData);
    }
    
    
    private void OpenInteraction()
    {
        if(_isInteractable) return;
        _isInteractable = true;
        
        interactionMenuHolder.localScale = Vector3.zero;
        interactionMenuHolder.gameObject.SetActive(true);
        interactionMenuHolder.DOScale(Vector3.one, 0.4f).SetEase(Ease.OutBack);
    }

    private void CloseInteraction()
    {
        if(!_isInteractable) return;
        interactionMenuHolder.DOScale(Vector3.zero, 0.4f).SetEase(Ease.InBack).OnComplete(() =>
        {
            _isInteractable = false;
            interactionMenuHolder.gameObject.SetActive(false);
        });
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entered");
        if (other.CompareTag(Constants.Tags.Player))
        {
            OpenInteraction();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(Constants.Tags.Player))
        {
            CloseInteraction();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuUI : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    
    [SerializeField] private List<ShopSlot> shopSideSlots;
    [SerializeField] private List<ShopSlot> inventorySideSlots;

    private List<ShopSlot> usedSlots = new List<ShopSlot>();


    private void Start()
    {
        exitButton.onClick.AddListener(UIManager.Instance.CloseShopMenu);
    }

    private void Initialize(List<ItemData> itemDatas)
    {
        ClearSlots();

        for (int i = 0; i < shopSideSlots.Count; i++)
        {
            // Amount will be undefined, gonna make it scrollable!
            shopSideSlots[i].Populate(itemDatas[i]);
            usedSlots.Add(shopSideSlots[i]);
        }

        for (int i = 0; i < Inventory.Instance.itemsStored.Count; i++)
        {
            // Amount is defined by inventory already no need to check
            inventorySideSlots[i].Populate(Inventory.Instance.itemsStored[i]);
            usedSlots.Add(inventorySideSlots[i]);
        }
    }

    private void ClearSlots()
    {
        usedSlots.ForEach(slot => slot.Clear());
    }


    public void OpenMenu(List<ItemData> itemDatas)
    {
        Initialize(itemDatas);

        transform.localScale = Vector3.zero;
        gameObject.SetActive(true);

        transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
    }

    public void CloseMenu()
    {
        transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack).OnComplete(() =>
        {
            gameObject.SetActive(false);
            ClearSlots();
        });
    }
}
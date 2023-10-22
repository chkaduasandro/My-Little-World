using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuUI : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    
    [SerializeField] private ShopSlot shopSlotPrefab;
    [SerializeField] private RectTransform shopSlotContent;
    
    [SerializeField] private List<ShopSlot> inventorySideSlots;
    
    private List<ShopSlot> generatedSlots = new List<ShopSlot>();

    private bool _isOpened;


    private void Start()
    {
        exitButton.onClick.AddListener(UIManager.Instance.CloseShopMenu);
    }

    private void Initialize(List<ItemData> itemDatas)
    {
        ClearSlots();

        for (int i = 0; i < itemDatas.Count; i++)
        {
            // Amount will be undefined, gonna make it scrollable!
            var shopSlot = Instantiate(shopSlotPrefab, shopSlotContent);
            shopSlot.Populate(itemDatas[i]);
            generatedSlots.Add(shopSlot);
        }

        for (int i = 0; i < Inventory.Instance.itemsStored.Count; i++)
        {
            // Amount is defined by inventory already no need to check
            inventorySideSlots[i].Populate(Inventory.Instance.itemsStored[i]);
        }
    }

    private void ClearSlots()
    {
        generatedSlots.ForEach(slot =>
        {
            Destroy(slot.gameObject);
        });
        generatedSlots.Clear();

        inventorySideSlots.ForEach(slot => slot.Clear());
    }


    public void OpenMenu(List<ItemData> itemDatas)
    {
        if (_isOpened) return;
        _isOpened = true;
        
        Initialize(itemDatas);

        transform.localScale = Vector3.zero;
        gameObject.SetActive(true);

        transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
    }

    public void CloseMenu()
    {
        if (!_isOpened) return;
        _isOpened = false;

        transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack).OnComplete(() =>
        {
            gameObject.SetActive(false);
            ClearSlots();
        });
    }
}
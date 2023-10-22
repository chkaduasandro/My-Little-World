using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenuUI : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Button tradeButton;

    [SerializeField] private TMP_Text exchangeAmount;
    [SerializeField] private TMP_Text balanceAmount;
    
    [SerializeField] private ShopSlot shopSlotPrefab;
    [SerializeField] private RectTransform shopSlotContent;
    
    [SerializeField] private List<ShopSlot> inventorySideSlots;
    private List<ShopSlot> shopSideSlots = new List<ShopSlot>();

    private bool _isOpened;
    private Shop _accessedShop;
    

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
            shopSlot.Populate(itemDatas[i],Recalculate);
            shopSideSlots.Add(shopSlot);
        }

        for (int i = 0; i < Inventory.Instance.itemsStored.Count; i++)
        {
            // Amount is defined by inventory already no need to check
            inventorySideSlots[i].Populate(Inventory.Instance.itemsStored[i], Recalculate);
        }
        
        tradeButton.onClick.RemoveAllListeners();
        tradeButton.onClick.AddListener(() =>
        {
            if (TryExchange(out var bought, out var sold))
            {
                bought.ForEach(data => Inventory.Instance.AddItem(data));
                sold.ForEach(data => Inventory.Instance.RemoveItem(data));
                
                sold.ForEach(data => _accessedShop.AddItem(data));
                bought.ForEach(data => _accessedShop.RemoveItem(data));
            }
        });
    }
    
    
    // This should not be in UI but no time to write another system.
    public bool TryExchange(out List<ItemData> bought, out List<ItemData> sold)
    {
        bought = new List<ItemData>();
        sold = new List<ItemData>();

        if (Inventory.Instance.coinAount < -CalculateExchange())
        {
            Debug.Log("Not Enough Money");
            return false;
        }

        if (Inventory.Instance.FreeSpaceCount < bought.Count)
        {
            Debug.Log("Not Enough Space");
            return false;
        }
        
        Inventory.Instance.coinAount += CalculateExchange();

        bought = GetSelectedShopSide();
        sold = GetSelectedInventorySide();
        return true;
    }


    private void Recalculate()
    {
        exchangeAmount.text = CalculateExchange().ToString("F2");
        balanceAmount.text = Inventory.Instance.coinAount.ToString();
    }

    private double CalculateExchange()
    {
        return GetSelectedInventorySide().Sum(data => data.Price) - GetSelectedShopSide().Sum(data => data.Price);
    }

    private List<ItemData> GetSelectedInventorySide()
    {
        return inventorySideSlots.Where(slot => slot.GetItemData != null && slot.isSelected).Select(slot => slot.GetItemData).ToList();
    }

    private List<ItemData> GetSelectedShopSide()
    {
        return shopSideSlots.Where(slot => slot.GetItemData != null && slot.isSelected).Select(slot => slot.GetItemData).ToList();
    }

    private void ClearSlots()
    {
        shopSideSlots.ForEach(slot =>
        {
            Destroy(slot.gameObject);
        });
        shopSideSlots.Clear();

        inventorySideSlots.ForEach(slot => slot.Clear());
    }


    public void OpenMenu(Shop shop,List<ItemData> itemDatas)
    {
        if (_isOpened) return;
        _isOpened = true;
        _accessedShop = shop;
        
        Initialize(itemDatas);
        Recalculate();

        transform.localScale = Vector3.zero;
        gameObject.SetActive(true);

        transform.DOKill();
        transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
    }

    public void CloseMenu()
    {
        if (!_isOpened) return;
        _isOpened = false;
        _accessedShop = null;

        transform.DOKill();
        transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack).OnComplete(() =>
        {
            gameObject.SetActive(false);
            ClearSlots();
        });
    }
}
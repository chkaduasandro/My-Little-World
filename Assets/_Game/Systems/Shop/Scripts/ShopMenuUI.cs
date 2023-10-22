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


    private List<ShopSlot> selectedBuySlot = new ();
    private List<ShopSlot> selectedSellSlot = new ();

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
            shopSlot.Populate(itemDatas[i],Recalculate);
            shopSideSlots.Add(shopSlot);
        }

        for (int i = 0; i < Inventory.Instance.itemsStored.Count; i++)
        {
            // Amount is defined by inventory already no need to check
            inventorySideSlots[i].Populate(Inventory.Instance.itemsStored[i], Recalculate);
        }
        
    }


    private void Recalculate()
    {
        var inventorySideSum = inventorySideSlots.Select(slot => slot).Where(slot => slot.GetItemData != null && slot.isSelected).Sum(slot => slot.GetItemData.Price);
        var shopSideSum = shopSideSlots.Select(slot => slot).Where(slot => slot.GetItemData != null && slot.isSelected).Sum(slot => slot.GetItemData.Price);

        exchangeAmount.text = (inventorySideSum - shopSideSum).ToString("F2");
        balanceAmount.text = Inventory.Instance.coinAount.ToString();
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


    public void OpenMenu(List<ItemData> itemDatas)
    {
        if (_isOpened) return;
        _isOpened = true;
        
        Initialize(itemDatas);
        Recalculate();

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
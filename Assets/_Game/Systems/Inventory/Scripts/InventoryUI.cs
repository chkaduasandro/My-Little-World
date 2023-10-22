using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUI : PlayerUI
{
    private Inventory inventory;

    [SerializeField] private TMP_Text coinAmount;
    [SerializeField]private List<InventorySlot> _inventorySlots;
    private void Start()
    {
        inventory = Inventory.Instance;
        
        UpdateUi();
        UpdateUiCoins();
        inventory.onItemsUpdate += UpdateUi;
        inventory.onCoinsUpdate += UpdateUiCoins;
    }

    private void UpdateUi()
    {
        for (int i = 0; i < _inventorySlots.Count; i++)
        {
            var slot = _inventorySlots[i];
            
            if(i < inventory.itemsStored.Count) slot.Populate(inventory.itemsStored[i]);
            else slot.Clear();
        }
    }

    private void UpdateUiCoins()
    {
        coinAmount.text = inventory.coinAount.ToString();
    }
}

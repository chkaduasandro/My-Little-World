using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    
    [SerializeField]private List<InventorySlot> _inventorySlots;
    private void Start()
    {
        inventory = Inventory.Instance;
        
        UpdateUi();
        inventory.onItemsUpdate += UpdateUi;
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
}

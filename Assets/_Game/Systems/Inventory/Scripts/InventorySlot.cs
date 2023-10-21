using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerDownHandler
{
    [HideInInspector] public ItemData itemData;
    
    [SerializeField] private Image iconImage;
    
    public void Populate(ItemData itemData)
    {
        this.itemData = itemData;
        iconImage.gameObject.SetActive(true);
        iconImage.sprite = itemData.IconUi;
    }

    public void Clear()
    {
        itemData = null;
        iconImage.gameObject.SetActive(false);
        iconImage.sprite = null;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            switch (itemData)
            {
                case Consumable consumable:
                    //consume
                    //TODO Use of game manager at this point!
                    Debug.Log("Consume");
                    
                    break;
                case Equipment equipment:
                    //equip
                    
                    Debug.Log("Equip");
                    break;
                default:
                    MouseInputController.Instance.InitializeMenu(new KeyValuePair<string, Action>("Drop",() => Inventory.Instance.RemoveItem(itemData)));
                    break;
            }
            
        }
    }
}

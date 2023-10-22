using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour, IPointerDownHandler
{
    [HideInInspector] public ClothingData clothingData;
    
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Image iconImage;

    public void Populate(ClothingData clothingData)
    {
        this.clothingData = clothingData;
        iconImage.gameObject.SetActive(true);
        iconImage.sprite = clothingData.IconUi;
    }

    public void Clear()
    {
        clothingData = null;
        iconImage.gameObject.SetActive(false);
        iconImage.sprite = defaultSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            switch (clothingData)
            {
                case ClothingData equipment:
                    Debug.Log("UnEquip");
                    MouseMenuController.Instance.InitializeMenu(
                        new KeyValuePair<string, Action>("UnEquip", () => Inventory.Instance.TakeOffClothing(equipment))
                    );
                    break;
                default:
                    break;
            }
        }
    }
}
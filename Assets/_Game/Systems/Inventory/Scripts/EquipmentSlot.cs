using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour, IPointerDownHandler
{
    [HideInInspector] public ClothingData clothingData;
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
        iconImage.sprite = null;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            switch (clothingData)
            {
                case ClothingData equipment:
                    Debug.Log("UnEquip");
                    MouseInputController.Instance.InitializeMenu(
                        new KeyValuePair<string, Action>("Equip", () => Inventory.Instance.TakeOffClothing(equipment))
                    );
                    break;
                default:
                    break;
            }
        }
    }
}
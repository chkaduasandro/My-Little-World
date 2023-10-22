using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public bool isSelected;
    public ItemData GetItemData => _itemData;

    [SerializeField] private Image iconImage;
    [SerializeField] private Image backGroundImage;
    [SerializeField] private Button button;

    private ItemData _itemData;


    public void Populate(ItemData itemData, Action onSelect = null)
    {
        this._itemData = itemData;
        iconImage.gameObject.SetActive(true);
        iconImage.sprite = itemData.IconUi;


        button.onClick.AddListener(() =>
        {
            if (_itemData != null)
            {
                if (isSelected) UnSelect();
                else Select();

                onSelect?.Invoke();
            }
        });
    }

    public void Clear()
    {
        _itemData = null;
        button.onClick.RemoveAllListeners();

        iconImage.gameObject.SetActive(false);
        iconImage.sprite = null;

        UnSelect();
    }

    public void Select()
    {
        isSelected = true;
        backGroundImage.gameObject.SetActive(true);
    }

    public void UnSelect()
    {
        isSelected = false;
        backGroundImage.gameObject.SetActive(false);
    }
}
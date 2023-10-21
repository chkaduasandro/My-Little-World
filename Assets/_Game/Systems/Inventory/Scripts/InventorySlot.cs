using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemData ItemData;

    [SerializeField] private Image iconImage;
    
    public void Populate(ItemData itemData)
    {
        this.ItemData = itemData;
        iconImage.gameObject.SetActive(true);
        iconImage.sprite = itemData.IconUi;
    }

    public void Clear()
    {
        this.ItemData = null;
        iconImage.gameObject.SetActive(false);
        iconImage.sprite = null;
    }
}

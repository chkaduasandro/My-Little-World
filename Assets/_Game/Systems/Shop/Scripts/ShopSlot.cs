using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image iconImage;
    private ItemData itemData;
    
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

    public void HighLight()
    {
        
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}

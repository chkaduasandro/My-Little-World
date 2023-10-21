using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private ItemData referenceItemData;
    
    private ItemData _itemData;

    private void Awake()
    {
        if (_itemData == null)
        {
            Initialize(Instantiate(referenceItemData));
        }
    }
    //TODO we have to make this Droppable

    public void Initialize(ItemData itemData)
    {
        _itemData = itemData;
    }

    public void PickUp()
    {
        Debug.Log($"Picking Up Item {_itemData.Id}");
        Inventory.Instance.AddItem(_itemData);
        Destroy(gameObject);
    }
}

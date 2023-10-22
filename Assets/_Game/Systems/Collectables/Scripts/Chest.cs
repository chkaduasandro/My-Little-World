using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interaction
{
    [SerializeField] private Transform openedChestTransform;
    [SerializeField] private Transform closedChestTransform;
    [SerializeField] private CircleCollider2D trigger;


    [Header("Reference Testing")]
    [SerializeField] private ItemData referenceItemData;
    private ItemData _itemData;

    private void Awake()
    {
        if (referenceItemData != null) Initialize(Instantiate(referenceItemData));
        
        openedChestTransform.gameObject.SetActive(false);
        closedChestTransform.gameObject.SetActive(true);
    }
    
    public void Initialize(ItemData itemData)
    {
        _itemData = itemData;
    }
    public override void OnInteracted()
    {
        PickUp();
        OpenChest();
        trigger.enabled = false;
    }
    private void OpenChest()
    {
        openedChestTransform.gameObject.SetActive(true);
        closedChestTransform.gameObject.SetActive(false);
    }

    public void PickUp()
    {
        Debug.Log($"Picking Up Item {_itemData.Id}");
        Inventory.Instance.AddItem(_itemData);
    }

}

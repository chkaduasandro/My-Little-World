using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interaction
{
    [SerializeField] private SpriteRenderer objectSprite;
    
    [Header("Reference Testing")]
    [SerializeField] private ItemData referenceItemData;
    
    private ItemData _itemData;

    private void Awake()
    {
        // If we want to place this object in scene.
        // Handling should be done by other manager or controller type script
        // Ill rework this after im done with other stuff!
        if (referenceItemData != null) Initialize(Instantiate(referenceItemData));
    }
    
    public override void OnInteracted()
    {
        PickUp();
    }

    public void Initialize(ItemData itemData)
    {
        _itemData = itemData;
        objectSprite.sprite = itemData.IconUi;
    }

    public void PickUp()
    {
        Debug.Log($"Picking Up Item {_itemData.Id}");
        
        Inventory.Instance.AddItem(_itemData);
        Destroy(gameObject);
    }
}

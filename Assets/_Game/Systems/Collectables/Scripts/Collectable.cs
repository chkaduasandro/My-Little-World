using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public ItemData itemData;
    public void PickUp()
    {
        Debug.Log($"Picking Up Item {itemData.Id}");
        Inventory.Instance.AddItem(itemData);
        Destroy(gameObject);
    }
}

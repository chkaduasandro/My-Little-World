using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Shop : Interaction
{
    // Bad Choice of parent but no time, too tired;
    // Hardcoded shop items, Remake to scriptable object may be?;
    [SerializeField] public List<ItemData> itemDatas;

    public override void OnInteracted()
    {
        UIManager.Instance.OpenShopMenu(this, itemDatas);
    }

    public void AddItem(ItemData itemData)
    {
        itemDatas.Add(itemData);
    }

    public void RemoveItem(ItemData itemData)
    {
        if (!itemDatas.Contains(itemData))
        {
            Debug.Log($"Shop does not contain item {itemData}");
            return;
        }
        itemDatas.Remove(itemData);
    }
    
}
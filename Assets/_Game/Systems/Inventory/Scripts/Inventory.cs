using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    public int slotAmount = 16;
    public List<ItemData> itemsStored;
    public event Action onItemChanged;


    public void AddItem(ItemData data)
    {
        if (itemsStored.Count >= slotAmount)
        {
            Debug.Log("Inventory Full");
            return;
        }

        itemsStored.Add(data);

        onItemChanged?.Invoke();
    }

    public void RemoveItem(ItemData data)
    {
        if (!itemsStored.Contains(data))
        {
            Debug.Log($"Inventory does not contain item {data}");
            return;
        }

        itemsStored.Remove(data);
        onItemChanged?.Invoke();
    }
}
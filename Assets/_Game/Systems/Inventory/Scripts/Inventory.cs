using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private Collectable collectablePrefab;

    public int slotAmount = 16;
    public List<ItemData> itemsStored = new ();
    public Dictionary<SkinType, ClothingData> clothingEquipped = new ();
    public event Action onItemsUpdate;
    public event Action onClothesUpdate;

        
    public void AddItem(ItemData data)
    {
        if (itemsStored.Count >= slotAmount)
        {
            Debug.Log("Inventory Full");
            return;
        }

        itemsStored.Add(data);

        onItemsUpdate?.Invoke();
    }

    public void DropItem(ItemData data)
    {
        RemoveItem(data);
        var collectable = Instantiate(collectablePrefab, GameManager.Instance.characterController.transform.position, Quaternion.identity);
        collectable.Initialize(data);
    }
    public void RemoveItem(ItemData data)
    {
        if (!itemsStored.Contains(data))
        {
            Debug.Log($"Inventory does not contain item {data}");
            return;
        }

        itemsStored.Remove(data);
        onItemsUpdate?.Invoke();
    }

    public void PutOnClothing(ClothingData clothingData)
    {
        if (clothingEquipped.TryGetValue(clothingData.Type, out var woreData))
        {
            TakeOffClothing(woreData);
            
            clothingEquipped[clothingData.Type] = clothingData;
            RemoveItem(clothingData);
        }
        else
        {
            clothingEquipped[clothingData.Type] = clothingData;
            RemoveItem(clothingData);
        }
        
        onClothesUpdate?.Invoke();
    }

    public void TakeOffClothing(ClothingData clothingData)
    {
        if (itemsStored.Count >= slotAmount)
        {
            Debug.Log("Inventory Full");
        }
        else
        {
            AddItem(clothingData);
            clothingEquipped.Remove(clothingData.Type);
        }
        
        onClothesUpdate?.Invoke();
    }
    
}
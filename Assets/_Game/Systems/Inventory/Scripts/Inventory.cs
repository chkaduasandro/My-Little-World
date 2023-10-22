using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    public double coinAount = 5000; // Creating basic int for coins... This usually is done in other managers, but for simplicity sake and for testing.
    public int FreeSpaceCount => _slotAmount - itemsStored.Count;

    public List<ItemData> itemsStored = new ();
    public Dictionary<SkinType, ClothingData> clothingEquipped = new ();
    public event Action onItemsUpdate;
    public event Action onClothesUpdate;
    public event Action onCoinsUpdate;

    [SerializeField] private Collectable collectablePrefab;

    public int _slotAmount = 16;

        
    public void AddItem(ItemData data)
    {
        if (itemsStored.Count >= _slotAmount)
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
        if (itemsStored.Count >= _slotAmount)
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

    public void UpdateCoins(int amount)
    {
        coinAount += amount;
        onCoinsUpdate?.Invoke();
    }

}
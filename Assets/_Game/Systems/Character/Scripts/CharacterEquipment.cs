using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEquipment : MonoBehaviour
{
    [SerializeField] private SpriteRenderer hoodRenderer;
    [SerializeField] private SpriteRenderer chestRenderer;

    [SerializeField] private Sprite defaultHood;
    [SerializeField] private Sprite defaultChest;

    private Inventory inventory;

    private void Start()
    {
        inventory = Inventory.Instance;
        inventory.onClothesUpdate += UpdateClothes;


        UpdateClothes();
    }

    public void UpdateClothes()
    {
        if (inventory.clothingEquipped.TryGetValue(SkinType.Hood, out var hoodClothing))
        {
            hoodRenderer.sprite = hoodClothing.Sprite;
        }
        else hoodRenderer.sprite = defaultHood;


        if (inventory.clothingEquipped.TryGetValue(SkinType.Chest, out var chestClothing))
        {
            chestRenderer.sprite = chestClothing.Sprite;
        }
        else chestRenderer.sprite = defaultChest;
    }
    
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClothes : MonoBehaviour
{
    [SerializeField] private SpriteRenderer hoodRenderer;
    [SerializeField] private SpriteRenderer chestRenderer;

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
        if (inventory.clothingEquipped.TryGetValue(SkinType.Chest, out var chestClothing))
        {
            chestRenderer.sprite = chestClothing.Sprite;
        }
    }
    
    
}

using UnityEngine;

public class EquipmentUI : PlayerUI
{
    private Inventory inventory;

    [SerializeField] private EquipmentSlot hoodSlot;
    [SerializeField] private EquipmentSlot chestSlot;
    [SerializeField] private EquipmentSlot pantsSLot;

    private void Start()
    {
        inventory = Inventory.Instance;
        
        UpdateUi();
        inventory.onClothesUpdate += UpdateUi;
    }

    private void UpdateUi()
    {
        if(inventory.clothingEquipped.TryGetValue(SkinType.Hood, out var hood))
        {
            hoodSlot.Populate(hood);
        }
        else hoodSlot.Clear();


        if (inventory.clothingEquipped.TryGetValue(SkinType.Chest, out var chest))
        {
            chestSlot.Populate(chest);
        }
        else chestSlot.Clear();
        
        if (inventory.clothingEquipped.TryGetValue(SkinType.Pants, out var pants))
        {
            pantsSLot.Populate(pants);
        }
        else pantsSLot.Clear();
    }
}
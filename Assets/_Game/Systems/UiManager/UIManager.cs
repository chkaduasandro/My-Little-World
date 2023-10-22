using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private EquipmentUI equipmentUI;
    [SerializeField] private ShopMenuUI shopMenuUI;


    

    public void OpenShopMenu(Shop shop,List<ItemData> itemDatas)
    {
        GameManager.Instance.SwitchControlState(ControlState.Interface);

        //Close Both Inventory and Equipment UI
        shopMenuUI.OpenMenu(shop,itemDatas);
        
        equipmentUI.CloseUI();
        inventoryUI.CloseUI();
    }

    public void CloseShopMenu()
    {
        GameManager.Instance.SwitchControlState(ControlState.Player);
        shopMenuUI.CloseMenu();
        
        equipmentUI.OpenUI();
        inventoryUI.OpenUI();
    }
}

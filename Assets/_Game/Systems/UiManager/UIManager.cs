using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TMP_Text headerText;
    
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

    public void HeaderScream(string text)
    {
        headerText.alpha = 1f;
        headerText.text = text;

        headerText.DOKill();
        headerText.DOFade(0, 3f).SetDelay(2f);
    }
}

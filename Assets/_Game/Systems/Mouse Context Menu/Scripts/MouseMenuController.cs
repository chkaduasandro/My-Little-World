using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public class MouseMenuController : Singleton<MouseMenuController>
{
    [SerializeField] private Transform menuHolder;
    [SerializeField] private MenuItemUI m_MenuItemUIPrefab;

    private List<MenuItemUI> generatedActionObjs = new();

    private ItemData _selectedSlot;
    private bool _isActive;


    private void LateUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            CloseMenu();
        }
    }

    public void InitializeMenu(params KeyValuePair<string, Action>[] actionKeyValues)
    {
        ClearMenu();

        foreach (var pair in actionKeyValues)
        {
            var contextAction = Instantiate(m_MenuItemUIPrefab, menuHolder);
            generatedActionObjs.Add(contextAction);

            var action = pair.Value;
            var actionName = pair.Key;

            contextAction.actionText.text = actionName;
            contextAction.actionButton.onClick.AddListener(() =>
            {
                action?.Invoke();
                CloseMenu();
            });
        }

        OpenMenu();
    }

    private void ClearMenu()
    {
        generatedActionObjs.ForEach(action => { Destroy(action.gameObject); });
        generatedActionObjs.Clear();
    }

    private void OpenMenu()
    {
        _isActive = true;
        menuHolder.DOKill();

        menuHolder.position = Input.mousePosition;
        menuHolder.gameObject.SetActive(true);

        menuHolder.localScale = Vector3.zero;
        menuHolder.DOScale(Vector3.one, 0.2f);
    }

    public void CloseMenu()
    {
        if(!_isActive) return;
        
        _isActive = false;
        menuHolder.DOKill();
        menuHolder.DOScale(Vector3.zero, 0.2f).OnComplete(() =>
        {
            menuHolder.gameObject.SetActive(false);
            ClearMenu();
        });
    }
}
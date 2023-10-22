using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MouseInputController : Singleton<MouseInputController>
{
    [SerializeField] private Transform menuHolder;
    [SerializeField] private MouseContextAction mouseContextActionPrefab;

    private List<MouseContextAction> generatedActionObjs = new();

    private ItemData selectedSlot;

    public void InitializeMenu(params KeyValuePair<string, Action>[] actionKeyValues)
    {
        ClearMenu();

        for (int i = 0; i < actionKeyValues.Length; i++)
        {
            var contextAction = Instantiate(mouseContextActionPrefab, menuHolder);
            generatedActionObjs.Add(contextAction);

            var pair = actionKeyValues[i];
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
        menuHolder.DOKill();

        menuHolder.position = Input.mousePosition;
        menuHolder.gameObject.SetActive(true);

        menuHolder.localScale = Vector3.zero;
        menuHolder.DOScale(Vector3.one, 0.2f);
    }

    public void CloseMenu()
    {
        menuHolder.DOKill();
        menuHolder.DOScale(Vector3.zero, 0.2f).OnComplete(() =>
        {
            menuHolder.gameObject.SetActive(false);
            ClearMenu();
        });
    }
}
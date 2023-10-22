using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    [SerializeField] protected InteractionButton interactionButton;
    [SerializeField] protected Transform interactionMenuHolder;

    protected bool _isInteractable;
    protected bool _isInitialized;

    protected virtual void Start()
    {
        interactionMenuHolder.gameObject.SetActive(false);

        if (_isInitialized) return;
        _isInitialized = true;

        interactionButton.OnClick += OnInteracted;
    }


    protected void OpenInteraction()
    {
        if (_isInteractable) return;
        _isInteractable = true;

        interactionMenuHolder.localScale = Vector3.zero;
        interactionMenuHolder.gameObject.SetActive(true);
        interactionMenuHolder.DOScale(Vector3.one, 0.4f).SetEase(Ease.OutBack);
    }

    protected void CloseInteraction()
    {
        if (!_isInteractable) return;
        interactionMenuHolder.DOScale(Vector3.zero, 0.4f).SetEase(Ease.InBack).OnComplete(() =>
        {
            _isInteractable = false;
            interactionMenuHolder.gameObject.SetActive(false);
        });
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Constants.Tags.Player))
        {
            OpenInteraction();
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(Constants.Tags.Player))
        {
            CloseInteraction();
        }
    }
    public abstract void OnInteracted();

}
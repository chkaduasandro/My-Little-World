using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterAnimation characterAnimation;


    private Vector2 _movementInput;
    private bool _isShifted;
    private bool _isFacingRight;

    private bool IsMoving => _movementInput.magnitude > 0;
    private bool IsRunning => IsMoving && _isShifted;


    // Update is called once per frame
    void Update()
    {
        UpdateInput();
        UpdateMovement();
        UpdateOrientation();
        UpdateAnimation();
    }

    private void UpdateInput()
    {
        _movementInput.x = Input.GetAxisRaw("Horizontal");
        _movementInput.y = Input.GetAxisRaw("Vertical");

        _isShifted = Input.GetKey(KeyCode.LeftShift);
    }

    private void UpdateMovement()
    {
        characterMovement.Move(_movementInput, _isShifted);
    }

    private void UpdateAnimation()
    {
        var speed = IsRunning ? 1.8f : 1;
        characterAnimation.MoveAnimation(IsMoving, speed);
    }

    private void UpdateOrientation()
    {
        if (Mathf.Abs(_movementInput.x) > 0)
        {
            _isFacingRight = _movementInput.x > 0;
            var rotation = _isFacingRight ? 0f : 180f;
            characterAnimation.transform.rotation = Quaternion.Euler(Vector3.up * rotation);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Constants.Tags.Collectable))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                var collectable = other.GetComponent<Collectable>();
                collectable.PickUp();
            }
        }
    }
}
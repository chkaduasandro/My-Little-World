using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private CharacterAnimation characterAnimation;


    [Header("Input")] 
    private float _horizontalInput;
    private float _verticalInput;
    private bool _isShifted;

    [Header("Orientation")] 
    private bool isFacingRight;

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
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        _isShifted = Input.GetKey(KeyCode.LeftShift);
    }

    private void UpdateMovement()
    {
        characterMovement.Move(_horizontalInput, _verticalInput,_isShifted);
    }

    private void UpdateAnimation()
    {
        if (IsRunning())
        {
            characterAnimation.MoveAnimation(true, 1.8f);
        }
        else if (IsMoving())
        {
            characterAnimation.MoveAnimation(true);
        }
        else
        {
            characterAnimation.MoveAnimation(false);
        }
        
    }

    private void UpdateOrientation()
    {
        if (_horizontalInput > 0 && !isFacingRight || _horizontalInput < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Debug.Log(isFacingRight);
            var rotation = isFacingRight ? 0f : 180f;
            characterAnimation.transform.rotation = Quaternion.Euler(Vector3.up * rotation);
        }
        
    }

    private bool IsMoving()
    {
        return _horizontalInput != 0 || _verticalInput != 0;
    }

    private bool IsRunning()
    {
        return IsMoving() && _isShifted;
    }
}
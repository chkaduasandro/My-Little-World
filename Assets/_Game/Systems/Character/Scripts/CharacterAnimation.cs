using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void MoveAnimation(bool isMoving, float animationSpeed = 1f)
    {
        animator.SetBool(Constants.Animation.Booleans.IsMoving, isMoving);
        animator.SetFloat(Constants.Animation.Floats.MoveSpeedMultiplier, animationSpeed);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float runMultiplier = 1.5f;

    [SerializeField] private float speedLerp = 1f;
    
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float horizontalInput, float verticalInput, bool running = false)
    {
        // Movement
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
        
        
        var targetSpeed = running ? moveSpeed * runMultiplier : moveSpeed;
        var speed = Mathf.Lerp(rb.velocity.magnitude, targetSpeed, speedLerp * Time.deltaTime);
        
        var velocity = moveDirection * speed;
        rb.velocity = velocity;
    }
    
}
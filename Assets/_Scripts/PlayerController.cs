using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : UsesInput
{
    private InputAction _move;
    private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed;

    protected override void Awake()
    {
        base.Awake();
        _move = _input.Player.Move;
        _rb = GetComponent<Rigidbody2D>();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _rb.linearVelocity = Vector2.zero;
    }
    
    

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 input = _move.ReadValue<Vector2>();
        Vector2 moveSpeed = input.normalized * _moveSpeed;

        _rb.linearVelocity = moveSpeed * Time.fixedDeltaTime;
    }
}
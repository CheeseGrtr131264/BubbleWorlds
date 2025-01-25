using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private InputMap _input;
    private InputAction _move;
    private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed;

    private void Awake()
    {
        _input = new InputMap();
        _move = _input.Player.Move;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
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

using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private InputMap _input;
    private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed;

    private void Awake()
    {
        _input = new InputMap();
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 input = _input.Player.Move.ReadValue<Vector2>();
        Vector2 moveSpeed = input.normalized * _moveSpeed;
        Debug.Log(moveSpeed.ToString());
        if (moveSpeed.magnitude > 0.05f)
        {
            return;
        }
        _rb.AddForce((Vector3)moveSpeed, ForceMode2D.Force);
    }
}

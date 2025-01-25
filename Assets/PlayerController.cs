using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerController;
    private Rigidbody2D _rb;
    [SerializeField] private float _moveSpeed;

    private void Awake()
    {
        _playerController = new PlayerInput();
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 input = _playerController.Player.Move.ReadValue<Vector2>();
        Vector2 moveSpeed = input.normalized * _moveSpeed;
        if (moveSpeed.magnitude > 0.05f)
        {
            return;
        }
        _rb.MovePosition(transform.position + (Vector3)moveSpeed);
        Debug.Log();
    }
}

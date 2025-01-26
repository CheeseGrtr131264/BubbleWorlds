using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private float _moveTime;
    [SerializeField] private Vector2 _moveAwayDistance;

    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    // void Update()
    // {
    //     // Get and interact with the closest Interactable that is inside _interactCollider
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         IInteractable closestInteractable = null;
    //         float closestDistance = Mathf.Infinity;
    //
    //         List<Collider2D> colliders = new List<Collider2D>();
    //         _interactCollider.Overlap(colliders);
    //         foreach (Collider2D collider in colliders)
    //         {
    //             if (collider.gameObject.GetComponent<IInteractable>() != null)
    //             {
    //                 IInteractable interactable = collider.gameObject.GetComponent<IInteractable>();
    //                 float currentDistance = Vector3.Distance(transform.position, collider.transform.position);
    //                 
    //                 if (closestInteractable == null || currentDistance < closestDistance)
    //                 {
    //                     closestInteractable = interactable;
    //                 }
    //             }
    //         }
    //         if (closestInteractable != null)
    //         {
    //             closestInteractable.Interact(_inventory);
    //         }
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            StartCoroutine(MoveToInteractable(other.gameObject, interactable));
        }
    }

    IEnumerator MoveToInteractable(GameObject obj, IInteractable interactable)
    {
        _playerController.enabled = false;
        
        GetComponent<Rigidbody2D>().DOMove(obj.transform.position, _moveTime);
        yield return new WaitForSeconds(_moveTime);
        
        interactable.Interact(_inventory);
        
        interactable.FinishedInteracting += StopInteracting;
    }

    private void StopInteracting(IInteractable interactable)
    {
        interactable.FinishedInteracting -= StopInteracting;
        StartCoroutine(MoveAwayFromInteractable());
    }

    IEnumerator MoveAwayFromInteractable()
    {
        
        Vector2 startPos = transform.position;
        GetComponent<Rigidbody2D>().DOMove(startPos + _moveAwayDistance, _moveTime);
        yield return new WaitForSeconds(_moveTime);
        
        _playerController.enabled = true;
    }
}

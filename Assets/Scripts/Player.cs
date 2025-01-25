using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private LightDetector _lightDetector;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Collider2D _interactCollider;

    private void Start()
    {
        _health.OnDied += _playerController.Health_OnDied;
        _lightDetector.OnLightChecked += _health.LightDetector_OnLightChecked;
        _lightDetector.OnLightSourceReached += _playerController.LightDetector_OnLightSourceReached;
    }

    void Update()
    {
        // Get and interact with the closest Interactable that is inside _interactCollider
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IInteractable closestInteractable = null;
            float closestDistance = Mathf.Infinity;

            List<Collider2D> colliders = new List<Collider2D>();
            _interactCollider.Overlap(colliders);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.GetComponent<IInteractable>() != null)
                {
                    IInteractable interactable = collider.gameObject.GetComponent<IInteractable>();
                    float currentDistance = Vector3.Distance(transform.position, collider.transform.position);
                    
                    if (closestInteractable == null || currentDistance < closestDistance)
                    {
                        closestInteractable = interactable;
                    }
                }
            }
            if (closestInteractable != null)
            {
                closestInteractable.Interact(_inventory);
            }
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField] private Collider2D _interactCollider;
    [SerializeField] private Inventory _inventory;

    void Update()
    {
        // Get and interact with the closest Interactable that is inside _interactCollider
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Spacebar pressed");
            IInteractable closestInteractable = null;
            float closestDistance = Mathf.Infinity;

            List<Collider2D> colliders = new List<Collider2D>();
            _interactCollider.Overlap(colliders);
            foreach (Collider2D collider in colliders)
            {
                print(collider.name);
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

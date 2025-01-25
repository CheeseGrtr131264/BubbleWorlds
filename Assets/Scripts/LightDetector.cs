using System;
using UnityEngine;
using System.Collections.Generic;

public class LightDetector : MonoBehaviour
{
    public event EventHandler<bool> OnLightChecked;
    public event EventHandler<Transform> OnLightSourceReached;

    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private ContactFilter2D _lightSourceContactFilter2D;

    private void FixedUpdate()
    {
        List<Collider2D> colliders = new List<Collider2D>();
        _rigidBody2D.Overlap(_lightSourceContactFilter2D, colliders);

        bool isInLightSource = (colliders.Count > 0);
        OnLightChecked?.Invoke(this, isInLightSource);

        if (isInLightSource)
        {
            Transform closestLightSourceTransform = null;
            float closestDistance = Mathf.Infinity;

            foreach (Collider2D collider in colliders)
            {
                float currentDistance = Vector3.Distance(transform.position, collider.transform.position);

                if (closestLightSourceTransform == null || currentDistance < closestDistance)
                {
                    closestLightSourceTransform = collider.transform;
                }
            }
            if (closestLightSourceTransform != null)
            {
                OnLightSourceReached?.Invoke(this, closestLightSourceTransform);
            }
        }
    }
}

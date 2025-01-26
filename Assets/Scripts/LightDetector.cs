using System;
using UnityEngine;

public class LightDetector : MonoBehaviour
{
    public event EventHandler<bool> OnLightChecked;
    public event EventHandler<Transform> OnLightSourceReached;

    [SerializeField] private float _lightDetectionRadius = 0.5f;
    [SerializeField] private LayerMask _lightSourceLayerMask;

    private void FixedUpdate()
    {
        Collider2D collider = null;
        collider = Physics2D.OverlapCircle(transform.position, _lightDetectionRadius, _lightSourceLayerMask);
        bool isInLightSource = collider != null;

        OnLightChecked?.Invoke(this, isInLightSource);

        if (collider != null)
        {
            OnLightSourceReached?.Invoke(this, collider.transform);
        }
    }
}

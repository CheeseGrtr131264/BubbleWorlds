using System;
using UnityEngine;

public class Candle : MonoBehaviour, IInteractable
{
    [SerializeField] private NPC _npc;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _lightSourceLight2D;
    [SerializeField] private GameObject _lightSource;
    private Inventory _lastPlayerInventory;

    public event Action<IInteractable> FinishedInteracting;

    void IInteractable.Interact(Inventory playerInventory)
    {
        _lastPlayerInventory = playerInventory;
        
        if (_lightSource)
        {
            _lightSource.SetActive(true);
        }

        if (_lightSourceLight2D)
        {
            _lightSourceLight2D.enabled = true;
            
            var _lightSourceSpriteRenderer = _lightSourceLight2D.GetComponent<SpriteRenderer>();
            if (_lightSourceSpriteRenderer)
            {
                _lightSourceSpriteRenderer.enabled = true;
            }
        }

        if (_npc.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            interactable.FinishedInteracting += interactableOnFinishedInteracting;
            interactable.Interact(_lastPlayerInventory);
        }
    }

    private void interactableOnFinishedInteracting(IInteractable interactable)
    {
        _npc.FinishedInteracting -= interactableOnFinishedInteracting;
        FinishedInteracting.Invoke(interactable);
    }
}

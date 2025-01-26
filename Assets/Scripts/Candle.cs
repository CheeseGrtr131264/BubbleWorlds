using System;
using UnityEngine;

public class Candle : MonoBehaviour, IInteractable
{
    [SerializeField] private NPC _npc;
    [SerializeField] private SpriteRenderer _npcSpriteRenderer;
    [SerializeField] private SpriteRenderer _lightSourceSpriteRenderer;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _lightSourceLight2D;

    public event Action<IInteractable> FinishedInteracting;

    void IInteractable.Interact(Inventory playerInventory)
    {
        if (_npcSpriteRenderer)
        {
            _npcSpriteRenderer.enabled = true;
        }
        if (_lightSourceSpriteRenderer)
        {
            _lightSourceSpriteRenderer.enabled = true;
        }
        if (_lightSourceLight2D)
        {
            _lightSourceLight2D.enabled = true;
        }

        if (_npc.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            interactable.Interact(playerInventory);
        }
    }
}

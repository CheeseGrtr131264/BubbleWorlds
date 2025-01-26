using System;
using UnityEngine;

public class Candle : MonoBehaviour, IInteractable
{
    [SerializeField] private NPC _npc;

    public event Action<IInteractable> FinishedInteracting;

    void IInteractable.Interact(Inventory playerInventory)
    {
        if (_npc.gameObject.TryGetComponent(out SpriteRenderer spriteRenderer))
        {
            spriteRenderer.enabled = true;
        }
        if (_npc.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            interactable.Interact(playerInventory);
        }
    }
}

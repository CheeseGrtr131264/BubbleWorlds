using System;
using UnityEngine;

public interface IInteractable
{
    void Interact(Inventory playerInventory);
    public event Action<IInteractable> FinishedInteracting;
}

using Ink.UnityIntegration;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    //[SerializeField] Dialog _dialogueHandler;
    [SerializeField] private TextAsset _inkFile;


    void IInteractable.Interact(Inventory playerInventory)
    {
        // pass the player's inventory as an argument to StartDialogue?
        DialogueManager.Instance.StartDialogue(playerInventory, _inkFile);
    }
}

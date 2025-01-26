using Ink.UnityIntegration;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    //[SerializeField] Dialog _dialogueHandler;
    [SerializeField] private TextAsset _inkFile;
    [SerializeField] private bool _hasRunDialogue;


    void IInteractable.Interact(Inventory playerInventory)
    {
        // pass the player's inventory as an argument to StartDialogue?
        if (!_hasRunDialogue)
        {
            DialogueManager.Instance.StartDialogue(playerInventory, _inkFile);
            _hasRunDialogue = true;
        }
    }
}

using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] DialogueHandler _dialogueHandler;


    void IInteractable.Interact(Inventory playerInventory)
    {
        // pass the player's inventory as an argument to StartDialogue?
        _dialogueHandler.StartDialogue(playerInventory);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

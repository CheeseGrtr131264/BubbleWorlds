using System;
using Ink.Runtime;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    //[SerializeField] Dialog _dialogueHandler;
    [SerializeField] private TextAsset _inkFile;
    [SerializeField] private bool _hasRunDialogue;
    [SerializeField] private Sprite _characterSprite;

    private Story _myStory;
    public Story MyStory => _myStory;

    private void Awake()
    {
        _myStory = new Story(_inkFile.text);
    }

    void IInteractable.Interact(Inventory playerInventory)
    {
        DialogueManager.Instance.StartDialogue(playerInventory, _myStory, _characterSprite);
        DialogueManager.Instance.AddListener(DialogueDone);
        _hasRunDialogue = true;
    }

    private void DialogueDone()
    {
        DialogueManager.Instance.RemoveListener(DialogueDone);
        FinishedInteracting?.Invoke(this);
    }

    public event Action<IInteractable> FinishedInteracting;
}

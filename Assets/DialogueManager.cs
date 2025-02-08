using System;
using Ink.Runtime;
using UnityCommunity.UnitySingleton;
using UnityEngine;

public class DialogueManager : MonoSingleton<DialogueManager>
{
    private Dialog _dialog;
    protected override void Awake()
    {
        base.Awake();
        _dialog = GetComponent<Dialog>();
    }

    public void StartDialogue(Inventory inventory, Story text, Sprite characterSprite)
    {
        _dialog.StartDialogue(inventory, text, characterSprite);
    }

    public void EndDialogue()
    {
        _dialog.LeaveDialogue();
    }

    public void AddDialogueDoneListener(Action action)
    {
        _dialog.OnDialogDone += action;
    } 
    public void RemoveListener(Action action)
    {
        _dialog.OnDialogDone -= action;
    } 
}

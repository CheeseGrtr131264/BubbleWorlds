using System;
using UnityEngine;
using System.Collections.Generic;
using Ink.Runtime;
using Ink.UnityIntegration;
using TMPro;
using UnityCommunity.UnitySingleton;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Dialog : UsesInput
{
    
    [SerializeField] private InkReader _inkReader;
    [SerializeField] private InventoryManager _inventoryManager;

    private Dictionary<string, List<string>> _dialogueDictionary = new Dictionary<string, List<string>>();
    private Inventory _playerInventory;
    private List<Word> _failedAttemptWordList = new List<Word>();

    public Action OnDialogDone;
    
    private SmartButton _cancel;

    protected override void Awake()
    {
        base.Awake();
        _cancel = new SmartButton(_input.Player.CancelDialogue);
        _smartButtonInputs.Add(_cancel);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _inkReader.OnDoneReadout.AddListener(OpenInventory);
        _inventoryManager.OnChoiceSelected.AddListener(ContinueStory);
    }

    protected override void Update()
    {
        base.Update();
        
        if (_cancel.Value())
        {
            Debug.Log("Canceling rn");
            LeaveDialogue();
            OnDialogDone.Invoke();
        }
    }
    
    

    private void ContinueStory()
    {
        _inkReader.ContinueStory();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _inkReader.OnDoneReadout.RemoveListener(OpenInventory);
        _inventoryManager.OnChoiceSelected.RemoveListener(ContinueStory);
    }


    private void OpenInventory()
    {
        _inventoryManager.OpenInventory();
    }

    public void StartDialogue(Inventory playerInventory, Story ink)
    {
        _playerInventory = playerInventory;
        var currentStory = ink;
        
        _inventoryManager.Setup(playerInventory, currentStory);
        _inkReader.Setup(currentStory);
    }

    public void LeaveDialogue()
    {
        _inventoryManager.CloseInventory();
        _inkReader.StopStory();
        _inkReader.HideReadout();
    }
}

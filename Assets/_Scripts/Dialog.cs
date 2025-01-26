using System;
using UnityEngine;
using System.Collections.Generic;
using Ink.Runtime;
using Ink.UnityIntegration;
using TMPro;
using UnityCommunity.UnitySingleton;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private Transform _wordButtonParent;
    [SerializeField] private WordUI _wordUIPrefab;
    [SerializeField] private InkReader _inkReader;

    private Dictionary<string, List<string>> _dialogueDictionary = new Dictionary<string, List<string>>();
    private Inventory _playerInventory;
    private List<Word> _failedAttemptWordList = new List<Word>();
    private Story _currentStory = null;

    private void OnEnable()
    {
        _inkReader.OnDoneReadout.AddListener(RefreshDialogueWordUIGrid);
    }
    
    private void OnDisable()
    {
        _inkReader.OnDoneReadout.RemoveListener(RefreshDialogueWordUIGrid);
    }

    public void StartDialogue(Inventory playerInventory, TextAsset ink)
    {
        ClearDialogueWordUIGrid();
        _playerInventory = playerInventory;
        _currentStory = new Story(ink.text);

        _inkReader.Setup(_currentStory);
    }

    private void AddWordToDialogueWordUI(Word word)
    {
        WordUI wordUI = Instantiate(_wordUIPrefab, _wordButtonParent);
        wordUI.Text = word.WordString;

        if (_dialogueDictionary.ContainsKey(word.WordString))
        {
            if (CheckIfAllValuesRemovedFromKey(word))
            {
                //make the dialogue word UI button unable to interact
                wordUI.GetComponent<Button>().interactable = false;
            }
        }
        wordUI.GetComponent<Button>().onClick.AddListener(() => OnWordUIButtonPressed(word));
    }

    private void RefreshDialogueWordUIGrid()
    {
        ClearDialogueWordUIGrid();

        foreach (Word word in _playerInventory.WordList)
        {
            if (_failedAttemptWordList.Contains(word) == false)
            {
                AddWordToDialogueWordUI(word);
            }
        }
    }

    private void ClearDialogueWordUIGrid()
    {
        for (var i = _wordButtonParent.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(_wordButtonParent.transform.GetChild(i).gameObject);
        }
    }

    private bool CheckIfAllValuesRemovedFromKey(Word word)
    {
        if (_dialogueDictionary.GetValueOrDefault(word.WordString).Count <= 0)
        {
            return true;
        }
        return false;
    }

    private void OnWordUIButtonPressed(Word word)
    {
        int choice = GetWordKey(word);
        _currentStory.ChooseChoiceIndex(choice);
        _inkReader.ContinueStory();
        
        //Remove that response value from dictionary
        _dialogueDictionary.GetValueOrDefault(word.WordString).RemoveAt(0);

        ClearDialogueWordUIGrid();
    }

    private int GetWordKey(Word word)
    {
        int choiceIndex = _currentStory.currentChoices.FindIndex((choice => choice.text == word.WordString));
        
        return choiceIndex;
        
            print("NPC's DialogueHandler does not have " + word);
            _failedAttemptWordList.Add(word);
            RefreshDialogueWordUIGrid();
            return -1;
    }
}

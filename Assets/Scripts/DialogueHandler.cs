using UnityEngine;
using System.Collections.Generic;

public class DialogueHandler : MonoBehaviour
{
    public string TestString;
    public string SecondTestString;

    [SerializeField] private Dictionary<string, string> _dialogueDictionary = new Dictionary<string, string>();
    [SerializeField] private List<Word> _dialogueWordList = new List<Word>();
    
    void Awake()
    {
        //TODO load excel data and put keys and values into dictionary
        _dialogueDictionary.Add(TestString, "Yes I recognize 'Hello'");
        _dialogueDictionary.Add(SecondTestString, "Yes I recognize 'Goodbye'");
    }

    public void StartDialogue(Inventory playerInventory)
    {
        // TEMP
        foreach (Word word in playerInventory.WordList)
        {
            if(CheckIfWordIsKey(word.WordString))
            {
                AddWordToDialogueWordList(word);
            }
        }
    }

    private void AddWordToDialogueWordList(Word word)
    {
        _dialogueWordList.Add(word);
        UpdateDialogueWordListUI();
    }

    private void RemoveWordFromDialogueWordList(Word word)
    {
        _dialogueWordList.Remove(word);
        UpdateDialogueWordListUI();
    }

    private void UpdateDialogueWordListUI()
    {
        foreach(Word word in _dialogueWordList)
        {
            //Test
            print(_dialogueDictionary.GetValueOrDefault(word.WordString));
        }
    }

    private bool CheckIfWordIsKey(string word)
    {
        if (_dialogueDictionary.ContainsKey(word))
        {
            return true;
        }
        else
        {
            print("NPC's DialogueHandler does not have " + word);
            return false;
        }
    }
}

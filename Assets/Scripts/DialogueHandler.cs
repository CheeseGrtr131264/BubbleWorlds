using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{
    public string TestString;
    public string SecondTestString;

    [SerializeField] private Dictionary<string, string> _dialogueDictionary = new Dictionary<string, string>();
    [SerializeField] private List<Word> _dialogueWordList = new List<Word>();
    [SerializeField] private DialogueWordUI _dialogueWordUI;
    [SerializeField] private GameObject _wordUIPrefab;

    private GridLayoutGroup _dialogueWordUIGrid;
    
    void Awake()
    {
        _dialogueWordUIGrid = _dialogueWordUI.Canvas.GetComponent<GridLayoutGroup>();

        //TODO load excel data and put keys and values into dictionary
        _dialogueDictionary.Add(TestString, "Yes I recognize 'Hello'");
        _dialogueDictionary.Add(SecondTestString, "Yes I recognize 'Goodbye'");
    }

    public void StartDialogue(Inventory playerInventory)
    {
        // TEMP
        foreach (Word word in playerInventory.WordList)
        {
            TryAddWordToDialogueWordList(word);
        }
    }

    private void TryAddWordToDialogueWordList(Word word)
    {
        if (_dialogueWordList.Contains(word) == false)
        {
            _dialogueWordList.Add(word);
            UpdateDialogueWordListUI();
        }
    }

    private void RemoveWordFromDialogueWordList(Word word)
    {
        _dialogueWordList.Remove(word);
        UpdateDialogueWordListUI();
    }

    private void UpdateDialogueWordListUI()
    {
        if (_dialogueWordUIGrid.transform.childCount >= 0)
        {
            foreach (Transform child in _dialogueWordUIGrid.transform)
            {
                Destroy(child.gameObject);
            }
        }
        foreach (Word word in _dialogueWordList)
        {
            GameObject wordUIGameObject = Instantiate(_wordUIPrefab, _dialogueWordUIGrid.transform);
            TMP_Text wordUIText = wordUIGameObject.GetComponent<WordUI>().TextMeshPro;
            wordUIText.text = word.WordString;
            wordUIGameObject.GetComponent<Button>().onClick.AddListener(() => OnWordUIButtonPressed(word));
        }
    }

    private void OnWordUIButtonPressed(Word word)
    {
        if (CheckIfWordIsKey(word.WordString))
        {
            print(_dialogueDictionary.GetValueOrDefault(word.WordString));
        }
        //Do we want to just grey out the word when you talk to them?
        RemoveWordFromDialogueWordList(word);

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

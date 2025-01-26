using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{
    public string TestString;
    public string SecondTestString;

    [SerializeField] private DialogueWordUI _dialogueWordUI;
    [SerializeField] private GameObject _wordUIPrefab;

    private Dictionary<string, List<string>> _dialogueDictionary = new Dictionary<string, List<string>>();
    private GridLayoutGroup _dialogueWordUIGrid;
    private Inventory _playerInventory;
    private List<Word> _failedAttemptWordList = new List<Word>();
    
    void Awake()
    {
        _dialogueWordUIGrid = _dialogueWordUI.Canvas.GetComponent<GridLayoutGroup>();

        //TODO load excel data and put keys and values into dictionary
        _dialogueDictionary.Add(TestString, new List<string>() { "Yes I recognize 'Hello'" });
        _dialogueDictionary.Add(SecondTestString, new List<string>() { "Yes I recognize 'Goodbye'", "Yes I also recognize 'Goodbye'" });
    }

    public void StartDialogue(Inventory playerInventory)
    {
        ClearDialogueWordUIGrid();

        _playerInventory = playerInventory;
        foreach (Word word in _playerInventory.WordList)
        {
            if (_failedAttemptWordList.Contains(word) == false)
            {
                AddWordToDialogueWordUI(word);
            }
        }
    }

    private void AddWordToDialogueWordUI(Word word)
    {
        GameObject wordUIGameObject = Instantiate(_wordUIPrefab, _dialogueWordUIGrid.transform);
        WordUI wordUIText = wordUIGameObject.GetComponent<WordUI>();
        wordUIText.Text = word.WordString;

        if (_dialogueDictionary.ContainsKey(word.WordString) == true)
        {
            if (CheckIfAllValuesRemovedFromKey(word))
            {
                //make the dialogue word UI button unable to interact
                wordUIGameObject.GetComponent<Button>().interactable = false;
            }
        }
        wordUIGameObject.GetComponent<Button>().onClick.AddListener(() => OnWordUIButtonPressed(word));
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
        for (var i = _dialogueWordUIGrid.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(_dialogueWordUIGrid.transform.GetChild(i).gameObject);
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
        if (CheckIfWordIsKey(word))
        {
            //TODO Send the word to Ink?
            print(_dialogueDictionary.GetValueOrDefault(word.WordString)[0]);

            //Remove that response value from dictionary
            _dialogueDictionary.GetValueOrDefault(word.WordString).RemoveAt(0);

            //refresh UI
            RefreshDialogueWordUIGrid();
        }
    }

    private bool CheckIfWordIsKey(Word word)
    {
        if (_dialogueDictionary.ContainsKey(word.WordString))
        {
            return true;
        }
        else
        {
            print("NPC's DialogueHandler does not have " + word);
            _failedAttemptWordList.Add(word);
            RefreshDialogueWordUIGrid();
            return false;
        }
    }
}

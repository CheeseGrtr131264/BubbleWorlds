using DG.Tweening;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.Events;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Transform _wordButtonParent;
    [SerializeField] private WordUI _wordUIPrefab;
    [Space]
    [SerializeField] private float _shownY;
    [SerializeField] private float _hiddenY;
    [SerializeField] private float _lerpTime;
    [SerializeField] private WordMono _defaultWord;

    public UnityEvent OnChoiceSelected;
    
    
    private RectTransform _rect;
    private Inventory _playerInventory;
    private Story _currentStory;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }

    public void Setup(Inventory playerInventory, Story currentStory)
    {
        _currentStory = currentStory;
        _playerInventory = playerInventory;
    }
    public void OpenInventory()
    {
        RefreshDialogueWordUIGrid();
        _rect.DOAnchorPosY(_shownY, _lerpTime);
        
    }

    public void CloseInventory()
    {
        _rect.DOAnchorPosY(_hiddenY, _lerpTime);
    }
    
    public void AddWordToDialogueWordUI(Word word)
    {
        WordUI wordUI = Instantiate(_wordUIPrefab, _wordButtonParent);
        wordUI.Text = word.WordString;

        // if (_dialogueDictionary.ContainsKey(word.WordString))
        // {
        //     // if (CheckIfAllValuesRemovedFromKey(word))
        //     // {
        //     //     //make the dialogue word UI button unable to interact
        //     //     wordUI.GetComponent<Button>().interactable = false;
        //     // }
        // }
        wordUI.AddButtonCallback(() => OnWordUIButtonPressed(word));
    }

    private void RefreshDialogueWordUIGrid()
    {
        ClearDialogueWordUIGrid();

        foreach (Word word in _playerInventory.WordList)
        {
            AddWordToDialogueWordUI(word);
        }
    }

    private void ClearDialogueWordUIGrid()
    {
        for (var i = _wordButtonParent.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(_wordButtonParent.transform.GetChild(i).gameObject);
        }
    }

    // private bool CheckIfAllValuesRemovedFromKey(Word word)
    // {
    //     if (_dialogueDictionary.GetValueOrDefault(word.WordString).Count <= 0)
    //     {
    //         return true;
    //     }
    //     return false;
    // }

    private void OnWordUIButtonPressed(Word word)
    {
        if (word.WordString == "leave")
        {
            DialogueManager.Instance.EndDialogue();
            return;
        }
        int choice = GetWordKey(word);
        _currentStory.ChooseChoiceIndex(choice);
        OnChoiceSelected.Invoke();
        
        CloseInventory();
        ClearDialogueWordUIGrid();
    }

    private int GetWordKey(Word word)
    {
        int choiceIndex = _currentStory.currentChoices.FindIndex((choice => choice.text.ToLower() == word.WordString));
        if (choiceIndex == -1)
        {
            return GetWordKey(_defaultWord.MyWord);
        }
        
        return choiceIndex;
    }
}

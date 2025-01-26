using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DG.Tweening;
using Ink.Runtime;
using Ink.UnityIntegration;
using TMPro;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class InkReader : UsesInput
{
    public static event Action<Story> OnCreateStory;
    public UnityEvent OnDoneReadout;
    public Story _story;

    [SerializeField] private Canvas canvas = null;


    // UI Prefabs
    [SerializeField] private TMP_Text _textReadout;

    [SerializeField] private bool _doneWithStory;

    [SerializeField] private float _letterDelay;

    private SmartButton _proceed;

    [SerializeField] private float _dotDelay;
    [SerializeField] private Button buttonPrefab;
    private List<Button> _buttons = new();

    private string _lastSelectedWord;
    private Coroutine _storyCoroutine;
    private RectTransform _rect;
    
    [SerializeField] private float _shownY;
    [SerializeField] private float _hiddenY;
    [SerializeField] private float _lerpTime;
    [SerializeField] private WordButton _wordButtonPrefab;

    private List<WordButton> _wordButtons = new();
    public Action<WordButton> OnButtonAdded;
    [SerializeField] private float _newWordDelay;
    [SerializeField] private Transform _buttonSpawnCanvas;
    private Inventory _inventory;


    protected override void Awake()
    {
        _rect = GetComponent<RectTransform>();
        base.Awake();
        _proceed = new SmartButton(_input.Player.ProceedDialogue);
        _smartButtonInputs.Add(_proceed);
        // ClearView();
        // StartStory();
    }
    
    public void Setup(Inventory inventory, Story story)
    {
        _story = story;
        _inventory = inventory;
        ShowReadout();
        StartStory();
    }

    public void HideReadout()
    {
        _rect.DOAnchorPosY(_hiddenY, _lerpTime);
    }
    public void ShowReadout()
    {
        _rect.DOAnchorPosY(_shownY, _lerpTime);
    }

    public void StopStory()
    {
        if (_storyCoroutine != null)
        {
            StopCoroutine(_storyCoroutine);
            _storyCoroutine = null;
        }
        ClearView();
    }

    // Creates a new Story object with the compiled story which we can then play!
    private void StartStory()
    {
        ClearView();
        if (OnCreateStory != null) OnCreateStory(_story);
        
        _storyCoroutine = StartCoroutine(PlayStory(true));
    }

    public void ContinueStory()
    {
        StartCoroutine(PlayStory(false));
    }

    // This is the main function called every time the story changes. It does a few things:
    // Destroys all the old content and choices.
    // Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
    IEnumerator PlayStory(bool delayStart)
    {
        // Remove all the UI on screen
        //ClearView();
        if (delayStart)
        {
            yield return new WaitForSeconds(_lerpTime);
        }
        else
        {
            _story.Continue();
        }
        
        // Read all the content until we can't continue any more
        while (_story.canContinue)
        {
            yield return null;
            ClearView();
            // Continue gets the next line of the story
            string text = _story.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            yield return ReadoutLine(text);

            if (_story.currentTags.Count > 0)
            {
                ParseTags(_story.currentTags);
            }

            if (_story.canContinue)
            {
                yield return ShowDots();
                
            }
        }
        
        BroadcastFinished();
    }

    private void ParseTags(List<string> tags)
    {
        // foreach (var tag in tags)
        // {
        //     if (tag.Contains("Points"))
        //     {
        //         int pointsToGain = Int16.Parse(tag.Substring(6));
        //         Debug.Log($"Gained {pointsToGain} points");
        //     }
        // }
    }

    private void BroadcastFinished()
    {
        Debug.Log("Finished it");
        OnDoneReadout.Invoke();
    }

    private IEnumerator ReadoutLine(string text)
    {
        char[] letters = text.ToCharArray();
        int i = 0;
        bool _makingButton = false;

        // StringBuilder sb = new StringBuilder();
        // for (int counter = 0; counter < text.Length; counter++)
        // {
        //     sb.Append(" ");
        // }
        //
        // _textReadout.text = sb.ToString();
        
        while (i < letters.Length)
        {
            //Check if user is trying to skip forward
            if (_proceed.Value())
            {
                //Don't let them skip if there's a word left lol
                if (text.IndexOf('[', i) == -1)
                {
                    Debug.Log("Breaking rn");
                    break;
                }
            }

            if (letters[i] == '[')
            {
                _makingButton = true;
                int firstLetter = i;
                int lastLetter = text.IndexOf(']', i) - 1;
                
                string word = text.Substring(firstLetter + 1, lastLetter - firstLetter);
                yield return null;
                
                //var wordLocation = _textReadout.transform.TransformPoint((firstCharInfo.topLeft + lastCharInfo.bottomRight) / 2f);
                // var topLeft = _textReadout.transform.TransformPoint(firstCharInfo.topLeft);
                // var bottomRight = _textReadout.transform.TransformPoint(lastCharInfo.bottomRight);
                
                WordButton newWordButton = Instantiate(_wordButtonPrefab, _buttonSpawnCanvas);
                //newWordButton.transform.position = wordLocation;//wordLocation, Quaternion.identity);
                newWordButton.Setup(firstLetter, lastLetter, _textReadout, word, _inventory);
                _wordButtons.Add(newWordButton);
                OnButtonAdded?.Invoke(newWordButton);
                i++;
            }
            else if (_makingButton)
            {
                if (letters[i] == ']')
                {
                    _makingButton = false;
                }
                else
                {
                    var letter = letters[i].ToString();
                    _wordButtons.Last().AppendText(letter);
                    AddToText(letter, i);
                }
                i++;
            }
            else
            {
                //Maybe add anim here
                AddToText(letters[i].ToString(), i);
                i++;
            }
            yield return new WaitForSeconds(_letterDelay);
        }

        if (i < letters.Length)
        {
            AddToText(text.Substring(i, letters.Length - 1 - i), i);
        }
        // for (int remainingLetters = i; remainingLetters < letters.Length; remainingLetters++)
        // {
        //     _textReadout.text += letters[remainingLetters];
        // }
            
        //Add newline character
        _textReadout.text += "\n";
        
        
        
       
    }

    private void AddToText(string text, int index)
    {
        //_textReadout.text = _textReadout.text.Substring(0, index) + text +_textReadout.text.Substring(index + text.Length);
        _textReadout.text += text;
        // foreach (var btn in _wordButtons)
        // {
        //     btn.UpdatePos();
        // }
    }
    private IEnumerator ShowDots()
    {
        //Add new lines
        _textReadout.text += "\n\n";
        
        //Show 3 dots
        int dotCount = 0;
        while (dotCount < 3)
        {
            _textReadout.text += ". ";
            yield return new WaitForSeconds(_dotDelay);
            dotCount++;
        }
        
        //Wait for proceed input
        while (true)
        {
            if (_proceed.Value())
            {
                break;
            }
            yield return null;
        }
        
    }


    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton (Choice choice) {
        _story.ChooseChoiceIndex (choice.index);
    }

    // Creates a button showing the choice text
    Button CreateChoiceView(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab, canvas.transform, false);
        _buttons.Add(choice);

        // Gets the text from the button prefab
        Text choiceText = choice.GetComponentInChildren<Text>();
        choiceText.text = text;

        // Make the button expand to fit the text
        HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
        layoutGroup.childForceExpandHeight = false;

        return choice;
    }
    
    /// <summary>
    /// Clears story view by erasing text and destroying buttons
    /// </summary>
    void ClearView()
    {
        _textReadout.text = "";
        _textReadout.textInfo.ClearMeshInfo(true);
        
        foreach (var button in _wordButtons)
        {
            Destroy(button.gameObject);
        }
        _wordButtons.Clear();
    }
}
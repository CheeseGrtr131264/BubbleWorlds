using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
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


    protected override void Awake()
    {
        _proceed = new SmartButton(_input.Player.ProceedDialogue);
        _smartButtonInputs.Add(_proceed);
        base.Awake();
        // ClearView();
        // StartStory();
    }
    
    public void Setup(Story story)
    {
        _story = story;
        StartStory();
    }

    // Creates a new Story object with the compiled story which we can then play!
    private void StartStory()
    {
        ClearView();
        if (OnCreateStory != null) OnCreateStory(_story);
        
        StartCoroutine(PlayStory());
    }

    public void ContinueStory()
    {
        StartCoroutine(PlayStory());
    }

    // This is the main function called every time the story changes. It does a few things:
    // Destroys all the old content and choices.
    // Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
    IEnumerator PlayStory()
    {
        // Remove all the UI on screen
        //ClearView();
        
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

            if (_story.canContinue)
            {
                yield return ShowDots();
            }
        }
        
        BroadcastFinished();
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

        while (i < letters.Length)
        {
            //Check if user is trying to skip forward
            if (_proceed.Value())
            {
                Debug.Log("Breaking rn");
                break;
            }
            
            //Maybe add anim here
            _textReadout.text += letters[i];
            i++;
            yield return new WaitForSeconds(_letterDelay);
        }
        
        for (int remainingLetters = i; remainingLetters < letters.Length; remainingLetters++)
        {
            _textReadout.text += letters[remainingLetters];
        }
            
        //Add newline character
        _textReadout.text += "\n";
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
        // foreach (var button in _buttons)
        // {
        //     Destroy(button.gameObject);
        // }
        // _buttons.Clear();
    }
}
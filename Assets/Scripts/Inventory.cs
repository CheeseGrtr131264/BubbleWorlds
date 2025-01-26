using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public List<WordMono> DebugWordList = new List<WordMono>();
    public List<Word> WordList = new List<Word>();

    private Dictionary<Story, List<WordInfo>> _npcData;
    public UnityEvent OnWordAdded;

    private void Awake()
    {
        _npcData = new Dictionary<Story, List<WordInfo>>();

    }

    private void Start()
    {
        foreach (var npc in FindObjectsByType<NPC>(FindObjectsInactive.Include, FindObjectsSortMode.None))
        {
            _npcData[npc.MyStory] = new List<WordInfo>();
        }
        
        foreach (var word in DebugWordList)
        {
            AddWord(word.MyWord);
        }
    }

    public bool HasWord(Word word)
    {
        return WordList.Any(word1 => word1 == word);
    }
    public void AddWord(Word word)
    {
        //Ensure no duplicates
        if (HasWord(word))
        {
            return;
        }
        
        WordList.Add(word);
        OnWordAdded.Invoke();
        //Add it to all npc's
        foreach (var npc in _npcData)
        {
            npc.Value.Add(new WordInfo(word, WordInfo.State.Unused));
        }
    }

    // public void RemoveWord(Word word)
    // {
    //     WordList.Remove(word);
    // }

    public void RecordAttempt(Story story, Word word, WordInfo.State state)
    {
        var storyList = _npcData[story];
        int attemptedWordIndex = _npcData[story].FindIndex((info => info.MyWord == word));
        storyList[attemptedWordIndex] = new WordInfo(word, state);
    }

    public List<WordInfo> GetNPCWordInfo(Story story)
    {
        return _npcData[story];
    }
}

public struct WordInfo
{
    public Word MyWord;
    public State MyState;

    public WordInfo(Word myWord, State myState)
    {
        MyWord = myWord;
        MyState = myState;
    }

    public enum State
    {
        Unused,
        Failed,
        Successful,
        MissedSomething
    }
}

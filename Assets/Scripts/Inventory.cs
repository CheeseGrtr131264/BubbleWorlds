using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<Word> WordList = new List<Word>();

    public void AddWord(Word word)
    {
        WordList.Add(word);
    }

    public void RemoveWord(Word word)
    {
        WordList.Remove(word);
    }
}

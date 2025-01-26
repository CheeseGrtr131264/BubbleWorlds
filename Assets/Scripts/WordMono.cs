using UnityEngine;

public class WordMono : MonoBehaviour
{
    public string WordString;
    public Word MyWord => new Word(WordString);
}
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;


public class WordUI : MonoBehaviour
{
    [FormerlySerializedAs("TextMeshPro")] [SerializeField] TMP_Text _text;

    public string Text
    {
        get => _text.text;
        set => _text.text = value;
    }
}

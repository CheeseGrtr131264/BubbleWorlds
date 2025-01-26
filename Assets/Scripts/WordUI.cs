using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class WordUI : MonoBehaviour
{
    [FormerlySerializedAs("TextMeshPro")] [SerializeField] TMP_Text _text;
    [FormerlySerializedAs("TextMeshPro")] [SerializeField] Button _button;

    public string Text
    {
        get => _text.text;
        set => _text.text = value;
    }

    public void AddButtonCallback(UnityAction action)
    {
        _button.onClick.AddListener(action);
    }
}

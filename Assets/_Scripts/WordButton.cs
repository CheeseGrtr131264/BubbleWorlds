using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WordButton : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;
	[SerializeField] private Vector2 _padding;
	[SerializeField] private float _ySize;
	private TMP_Text _parentText;
	private int _min;
	private int _max;

	public UnityEvent<Word> OnButtonClicked;

	private Word _myWord => new Word(_text.text);

	private void Awake()
	{
		GetComponent<Button>().onClick.AddListener(() => OnButtonClicked.Invoke(_myWord));
	}

	public void Setup(int min, int max, TMP_Text text, string name, Inventory inventory)
	{
		//GetComponent<RectTransform>().sizeDelta = size;
		_min = min;
		_max = max;
		_parentText = text;
		_text.text = "";
		
		//IF already clicked, disable on start
		if (inventory.HasWord(new Word(name)))
		{
			GetComponent<Button>().interactable = false;
		}

		UpdatePos();
	}

	public void AppendText(string text)
	{
		_text.text += text;
	}

	private void UpdateSize()
	{
		var min = _parentText.textInfo.characterInfo[_min];
		var max = _parentText.textInfo.characterInfo[_max];
		//Size shouldn't change
		var topLeft = _parentText.transform.TransformPoint(min.topLeft);
		var bottomRight = _parentText.transform.TransformPoint(max.bottomRight);
		var requiredSize = new Vector2(Mathf.Abs(topLeft.x - bottomRight.x), Mathf.Abs(topLeft.y - bottomRight.y));
		requiredSize.y = Mathf.Max(requiredSize.y, _ySize);
		requiredSize += _padding;
		GetComponent<RectTransform>().sizeDelta = requiredSize;
	}

	private void LateUpdate()
	{
		UpdatePos();
	}

	public void UpdatePos()
	{
		var min = _parentText.textInfo.characterInfo[_min];
		var max = _parentText.textInfo.characterInfo[_min + _text.text.Length];
		var wordLocation = _parentText.transform.TransformPoint((min.topLeft + max.bottomRight) / 2f);
		transform.position = wordLocation;
	}
}
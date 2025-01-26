using TMPro;
using UnityEngine;

public class WordButton : MonoBehaviour
{
	[SerializeField] private TMP_Text _text;
	public void Setup(Vector2 size, string name)
	{
		GetComponent<RectTransform>().sizeDelta = size;
		_text.text = name;
	}
}
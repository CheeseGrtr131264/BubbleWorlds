using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class SwitchAudioMixerState : MonoBehaviour
{
	public AudioMixerSnapshot mySnapshot;
	public AUdioMixerSnapshot baseSnapshot;
	public float fadeTime = 3.0f;
	public float delayTime = 0.0f;
	public GameObject player;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == player)
        {
			Debug.Log("MusicOnTriggerEnterCollision");
			mySnapshot.TransitionTo(fadeTime);

		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == player)
        {
			Debug.Log("MusicOnTriggerEnterCollision");
			baseSnapshot.TransitionTo(fadeTime);

		}
	}
}

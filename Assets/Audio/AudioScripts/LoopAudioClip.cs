using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopAudioClip : MonoBehaviour
{

    public AudioSource audiosourceA;
    public AudioSource audiosourceB;
    public AudioSource currentSource;
    public int currentSourceInt;
    public double reverbTime = 5.3334;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (audiosourceA.time > currentSource.clip.length - reverbTime)
        {
            if(currentSource == audiosourceA)
            {
                currentSource = audiosourceB;
            }

            else
            {
                currentSource = audiosourceA;
            }

            currentSource.Play();
            Debug.Log("LoopQueue");
        }
    }

}

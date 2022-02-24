using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayer : MonoBehaviour
{
    [Header("USE ONLY ONE, NOT BOTH")]
    [Tooltip("contiene lle audioclips da avviare randomicamente.")]
    public List<AudioClip> audioClips;
    [Space, Tooltip("contiene le posiozioni temporali di dove iniziare l'audio randomicamente.")]
    public List<float> timeSplits;


    bool isTime = false;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();

        if (source == null) Debug.LogError("No AudioSource found. Please place <audioPlayer> script into an object with AudioSource component.");
        if (audioClips.Count==0) isTime = true;
    }

    public void playAudio()
    {
        if (!source.isPlaying)
        { 
            int randomAudio;

            if (!isTime)
            {
                randomAudio = Random.RandomRange(0, audioClips.Count - 1);
                source.clip = audioClips[randomAudio];
            }
            else { randomAudio = (int)Random.RandomRange(0f, timeSplits.Count - 1f); }

            if (isTime)
                source.time=timeSplits[randomAudio];

            source.Play();
        }
    }

    public void stopAudio() { if (source.isPlaying) source.Stop(); }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this; 
    }

    // we could handle both with Fungus if there's time. 
    public AudioSource BGM;
    public AudioSource[] Ambience; 
  
    public AudioSource SoundFx;

    [Header("Redundant Clips for sound")]
    public AudioClip levelComplete;
    public AudioClip levelFail; 
    // for testing purposes. 
    private void Start()
    {
        PlayLevelBGM();
    }
    public void PlayLevelBGM()
    {
        BGM.enabled = true;
        BGM.Play();
        PlayLevelAmbience(Ambience); 
    }
    private void PlayLevelAmbience(AudioSource[] ambienceSources)
    {
        foreach (var amb in ambienceSources)
        {
            amb.enabled = true;
            amb.Play(); 
        }
    }

    public void PlayEffect(AudioClip sfxClip)
    {
        SoundFx.PlayOneShot(sfxClip);
    }

}

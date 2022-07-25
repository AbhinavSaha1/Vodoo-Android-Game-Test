using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    private void Awake()
    {
        foreach(Sound s in Sounds)
        {
           s.Source= gameObject.AddComponent<AudioSource>();
           s.Source.clip = s.Clip;

           s.Source.volume = s.Volume;
           s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
        }
    }
    private void Start()
    {
        Play("Background Music");
    }
    public void Play(string name)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == name);
        if (s == null) return;

        s.Source.Play();
    }
}

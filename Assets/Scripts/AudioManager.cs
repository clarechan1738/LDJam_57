using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.Rendering;

[Serializable]
public struct AudioClipWithKey
{
    public string key;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{

    //Making It An Instance
    public static AudioManager instance
    {
        get; private set;
    }

    //Temporary Audio Clip List
    [SerializeField] private AudioClipWithKey[] tempSFXList;
    private Dictionary<string, AudioClip> SFXList = new();

    //Main Audio Source
    public AudioSource source;

    public AudioClip page;
    public AudioClip drop;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            foreach (AudioClipWithKey acwk in tempSFXList)
            {
                SFXList.Add(acwk.key, acwk.clip);
            }

            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

    public void PlayVoiceSFX(string sfx)
    {
        if (SFXList.TryGetValue(sfx, out AudioClip clip))
        {
            source.pitch = ((float)UnityEngine.Random.Range(90, 110)) / 100f;
            source.PlayOneShot(clip);
        }
    }
}
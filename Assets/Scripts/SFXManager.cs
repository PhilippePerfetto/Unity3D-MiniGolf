using System;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private static SFXManager _instance;
    public static SFXManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SFXManager>();
            }
            return _instance;
        }
    }

    public AudioClip[] sfx;
    public AudioSource audioSource;

    public void PlaySfxById(int id)
    {
        Console.WriteLine("PlaySfxById");
        Console.WriteLine($"id={id}, sfx:{sfx?.Length}, audioSource = {audioSource}");
        var audio = sfx[id];
        if (audio == null)
        {
            throw new Exception("audio is null)");
        }
        if (audioSource == null)
        {
            throw new Exception("audio SOURCE is null)");
        }
        audioSource.PlayOneShot(audio);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour, IGameController
{
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioSource musicSource;

    public ManagerStatus status { get; private set; }
    public void Startup()
    {
        Debug.Log("Audio controller starting...");

        musicSource.ignoreListenerPause = true;
        musicSource.ignoreListenerVolume = true;

        SoundVolume = 1f;
        musicVolume = 1f;

        status = ManagerStatus.Started;
    }

    private float _musicVolume;
    public float musicVolume
    {
        get { return _musicVolume; }
        set
        {
            _musicVolume = value;
            musicSource.volume = _musicVolume;
        }
    }

    public float SoundVolume
    {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }

    public void PlaySound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
}

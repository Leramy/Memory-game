using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : MonoBehaviour
{
    [SerializeField] private GameObject  panel;
    public void Open()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
        gameObject.SetActive(true);
    }
    public void Close()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
        gameObject.SetActive(false);
    }
    public void OnSoundValue(float value)
    {
        Managers.Audio.SoundVolume = value;
    }
    public void OnMusicValue(float value)
    {
        Managers.Audio.musicVolume = value;
    }
}

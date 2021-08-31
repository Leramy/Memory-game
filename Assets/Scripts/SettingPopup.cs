using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : MonoBehaviour
{
    public void Open()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
    }
    public void Close()
    {
        Time.timeScale = 1f;
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

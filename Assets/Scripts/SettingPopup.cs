using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopup : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
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

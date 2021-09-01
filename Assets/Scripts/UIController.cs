using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingPopup settingPopup;
    [SerializeField] private TimeUpSetting timeUpSetting;

    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip MenuClickSound;
    [SerializeField] private AudioClip FailedSound;

    private int _score;

    void Awake()
    {
        Messenger.AddListener(GameEvent.SCORE_CHANGED, OnScoreChanged);
        Messenger.AddListener(GameEvent.TIME_UP, OnTimeUp);
        Messenger.AddListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.SCORE_CHANGED, OnScoreChanged);
        Messenger.RemoveListener(GameEvent.TIME_UP, OnTimeUp);
        Messenger.RemoveListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
    }

    private void Start()
    {
        settingPopup.Close();
        timeUpSetting.Close();
        _score = 0;
        scoreLabel.text = _score.ToString();

    }
    private void OnScoreChanged()
    {
        _score += 1;
        scoreLabel.text = _score.ToString();
    }
    public void OnOpenSettings()
    {
        soundSource.PlayOneShot(MenuClickSound);
        if (settingPopup.gameObject.activeSelf)
        {
            settingPopup.Close();
        }
        else settingPopup.Open();
    }

    public void OnTimeUp()
    {
        soundSource.PlayOneShot(FailedSound);
        timeUpSetting.Open();
    }

    public void OnLevelComplete()
    {
        Managers.Audio.musicVolume = 0.5f;
    }
 }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour, IGameController
{
    public ManagerStatus status { get; private set; } 

    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingPopup settingPopup;

    [SerializeField] private TimeUpSetting timeUpSetting;
    [SerializeField] private LevelCompleteSetting levelCompleteSetting;
    [SerializeField] private StartPanelSetting startPanelSetting;

    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip MenuClickSound;
    [SerializeField] private AudioClip FailedSound;
    [SerializeField] private AudioClip LevelComplete;

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

    public void Startup()
    {

        Debug.Log("UIController started...");

        settingPopup.Close();
        timeUpSetting.Close();
        levelCompleteSetting.Close();

        _score = 0;
        scoreLabel.text = _score.ToString();

        startPanelSetting.Open();

        status = ManagerStatus.Started;
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
        Controllers.Audio.musicVolume = 0.1f;

        soundSource.PlayOneShot(LevelComplete);
        levelCompleteSetting.Open();
    }
 }
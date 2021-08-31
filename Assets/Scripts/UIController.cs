using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingPopup settingPopup;

    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip MenuClickSound;

    private int _score;

    void Awake()
    {
        Messenger.AddListener(GameEvent.SCORE_CHANGED, OnScoreChanged);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.SCORE_CHANGED, OnScoreChanged);
    }

    private void Start()
    {
        settingPopup.Close();
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
        settingPopup.Open();
    }
}

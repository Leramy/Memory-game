using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUpSetting : MonoBehaviour
{
    [SerializeField] private GameObject TimeUpPanel;
    [SerializeField] private Text PlayAgainText;
    public void Open()
    {
        TimeUpPanel.SetActive(true);
        gameObject.SetActive(true);
        Controllers.Anim.TimeUp();
    }
    public void Close()
    {
        PlayAgainText.gameObject.SetActive(false);
        TimeUpPanel.SetActive(false);
        gameObject.SetActive(false);
    }

    public void PlayAgain()
    {
        Managers.Level.RestartCurrent();
    }

    public void GoToMenu()
    {
        Managers.Level.LoadMenu();
    }
}

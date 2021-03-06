using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteSetting : MonoBehaviour
{
    [SerializeField] private GameObject LevelCompletePanel;

    [SerializeField] private Text NextText;
    [SerializeField] private Text CurLevelText;
    public void Open()
    {
        LevelCompletePanel.SetActive(true);
        gameObject.SetActive(true);
        CurLevelText.text = Managers.Level.curLevel.ToString();
        Controllers.Anim.OnLevelComplete();
    }
    public void Close()
    {
        LevelCompletePanel.SetActive(false);
        NextText.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void PlayNext()
    {
        Managers.Level.GoToNext();
    }

    public void GoToMenu()
    {
        Managers.Level.LoadMenu();
    }
}

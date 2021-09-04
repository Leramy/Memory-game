using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteSetting : MonoBehaviour
{
    [SerializeField] private GameObject LevelCompletePanel;

    [SerializeField] private Text NextText;
    public void Open()
    {
        LevelCompletePanel.SetActive(true);
        gameObject.SetActive(true);
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
        // следующий уровень
    }

    public void GoToMenu()
    {

    }
}

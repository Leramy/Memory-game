using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public int curLevel { get; private set; }
    public int maxLevel { get; private set; }

    public void Startup()
    {
        Debug.Log("Level manager starting...");

        maxLevel = 3;

        curLevel = PlayerPrefs.GetInt("curLevel",0);

        status = ManagerStatus.Started;
    }
    public void GoToNext()
    {
        if (curLevel < maxLevel)
        {
            curLevel++;
            string name = "Level " + curLevel;
            Debug.Log("Loading " + name);
            SceneManager.LoadScene(name);
        }
        else
        {
            Debug.Log("Last Level!");
            Messenger.Broadcast(GameEvent.GAME_COMPLETE);
        }
    }

    public void SaveProgress()
    {
        Debug.Log("Progress saved!");
        PlayerPrefs.SetInt("curLevel", curLevel);
        PlayerPrefs.Save();
    }

    public void RestartCurrent()
    {
        string name = "Level " + curLevel;
        Debug.Log("Loading " + name);
        SceneManager.LoadScene(name);

    }

    public void LoadMenu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene("Menu");
    }

    public void StartNewGame()
    {
        Debug.Log("New Game started!");
        PlayerPrefs.SetInt("curLevel", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level 1");
    }
    public void QuiteGame()
    {
        Debug.Log("GameOver");
        Application.Quit();
    }
}

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
            string name = "Level" + curLevel;
            Debug.Log("Loading " + name);
            SceneManager.LoadScene(name);
        }
        else
        {
            Debug.Log("Last Level!");
            Messenger.Broadcast(GameEvent.GAME_COMPLETE);
        }
    }

    public void RestartCurrent()
    {
        string name = "Level" + curLevel;
        Debug.Log("Loading " + name);
        SceneManager.LoadScene(name);

    }
}

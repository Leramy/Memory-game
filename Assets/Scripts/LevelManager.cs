using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public GameObject LoadingScreen;
    public Slider bar;
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
            LoadNewScene(name);
        }
        else
        {
            Debug.Log("Last Level!");
            curLevel = 0;
            PlayerPrefs.SetInt("curLevel", curLevel);
            //SceneManager.LoadScene("Final");
            LoadNewScene("Final");
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
        // SceneManager.LoadScene(name);
        LoadNewScene(name);
    }

    public void LoadMenu()
    {
        Debug.Log("Menu");
        //SceneManager.LoadScene("Menu");
        LoadNewScene("Menu");
    }

    public void StartNewGame()
    {
        Debug.Log("New Game started!");
        curLevel = 1;
        PlayerPrefs.SetInt("curLevel", curLevel-1);
        PlayerPrefs.Save();
        //SceneManager.LoadScene("Level 1");
        LoadNewScene("Level 1");
    }
    public void QuiteGame()
    {
        Debug.Log("GameOver");
        Application.Quit();
    }

    public void LoadNewScene(string name)
    {
        LoadingScreen.SetActive(true);
      //  SceneManager.LoadScene(name);
        StartCoroutine(LoadAsync(name));

        
    }

    IEnumerator LoadAsync(string name)
    {
        Debug.Log("Coroutine start");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(name);

        while(!asyncLoad.isDone)
        {
            bar.value = asyncLoad.progress;
            yield return null;
        }
        LoadingScreen.SetActive(false);
    }
}

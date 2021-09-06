using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueUI : MonoBehaviour
{
    [SerializeField] private GameObject panel; 
    [SerializeField] private AudioClip ClickSound;
    public void Open()
    {
        panel.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }
    public void Close()
    {
        panel.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
    public void ContinueGame()
    {
        MenuSceneController.Audio.PlaySound(ClickSound);
        Managers.Level.GoToNext();
    }

    public void StartNewGame()
    {
        MenuSceneController.Audio.PlaySound(ClickSound);
        Managers.Level.StartNewGame();
    }
}

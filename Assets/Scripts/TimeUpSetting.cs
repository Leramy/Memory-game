using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUpSetting : MonoBehaviour
{
    [SerializeField] private AnimationController anim;

    [SerializeField] private GameObject TimeUpPanel;
    [SerializeField] private Text PlayAgainText;
    public void Open()
    {
        TimeUpPanel.SetActive(true);
        gameObject.SetActive(true);
        anim.TimeUp();
    }
    public void Close()
    {
        PlayAgainText.gameObject.SetActive(false);
        TimeUpPanel.SetActive(false);
        gameObject.SetActive(false);
    }

    public void PlayAgain()
    {
        Messenger.Broadcast(GameEvent.RESTART);
    }

    public void GoToMenu()
    {

    }
}

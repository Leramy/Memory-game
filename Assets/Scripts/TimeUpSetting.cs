using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUpSetting : MonoBehaviour
{
    [SerializeField] private GameObject TimeUpPanel;
    public void Open()
    {
        TimeUpPanel.SetActive(true);
        gameObject.SetActive(true);
    }
    public void Close()
    {
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

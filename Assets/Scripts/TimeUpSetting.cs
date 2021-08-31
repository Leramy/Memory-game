using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUpSetting : MonoBehaviour
{
   
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
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

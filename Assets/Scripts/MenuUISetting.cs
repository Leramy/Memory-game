using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUISetting : MonoBehaviour
{
    [SerializeField] private ContinueUI ContinuePopup;
    [SerializeField] private AudioClip ClickSound;
    public void Play()
    {
        MenuSceneController.Audio.PlaySound(ClickSound);
        if(Managers.Level.curLevel != 0)
        {
            gameObject.SetActive(false);
            ContinuePopup.Open();
            
        }
        else Managers.Level.GoToNext();
    }

    public void Exit()
    {
        MenuSceneController.Audio.PlaySound(ClickSound);
        Managers.Level.QuiteGame();
    }
}

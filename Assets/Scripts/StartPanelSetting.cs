using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelSetting : MonoBehaviour
{
    [SerializeField] private Text startText;
    [SerializeField] private AudioClip StartSound;

    public void Open()
    {
        gameObject.SetActive(true);
        StartCoroutine(StartGame());
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }

    public IEnumerator StartGame()
    {
        Controllers.Audio.musicVolume = 0.5f;

        startText.text = "Level";

        //startText.text = "Level " + Managers.Level.curLevel;

        yield return new WaitForSeconds(0.5f);

        startText.text = "READY";
        Controllers.Audio.PlaySound(StartSound);

        yield return new WaitForSeconds(1f);

        startText.text = "SET";
        Controllers.Audio.PlaySound(StartSound);

        yield return new WaitForSeconds(1f);

        startText.text = "GO";
        Controllers.Audio.PlaySound(StartSound);

        yield return new WaitForSeconds(1f);

        Controllers.Timer.stop = false;
        Controllers.Audio.musicVolume = 1f;

        Close();
    }
}

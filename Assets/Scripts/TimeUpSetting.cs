using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUpSetting : MonoBehaviour
{
    [SerializeField] private GameObject TimeUpPanel;
    [SerializeField] private Text PlayAgainText;
    public void Open()
    {
        TimeUpPanel.SetActive(true);
        gameObject.SetActive(true);
        StartCoroutine(TextAppearance());
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

    public IEnumerator TextAppearance()
    {
        yield return new WaitForSeconds(1f);

        PlayAgainText.gameObject.SetActive(true);
    }
}

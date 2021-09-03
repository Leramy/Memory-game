using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelSetting : MonoBehaviour
{
    [SerializeField] private Text startText;

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
        startText.text = "Level 1";

        yield return new WaitForSeconds(0.5f);

        startText.text = "READY";

        yield return new WaitForSeconds(0.5f);

        startText.text = "SET";

        yield return new WaitForSeconds(0.5f);

        startText.text = "GO";

        yield return new WaitForSeconds(0.5f);

        Managers.Timer.stop = false;

        Close();
    }
}

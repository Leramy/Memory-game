using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour, IGameController
{
    public ManagerStatus status { get; private set; }

    [SerializeField] private Text timerText;

    public float timeStart;

    private bool timeRunninOut = false;

    public bool stop;
    public void Startup()
    {
        Debug.Log("TimerController started...");

        //timeStart = 15f;
        timerText.text = timeStart.ToString();
        stop = true;

        status = ManagerStatus.Started;
    }

    void Update()
    {
        if (!stop)
        {
            if (Math.Round(timeStart) == 0)
            {
                Messenger.Broadcast(GameEvent.TIME_UP);
            }
            else
            {
                timeStart -= Time.deltaTime;
                timerText.text = Math.Round(timeStart).ToString();
                if (Math.Round(timeStart) <= 3 && !timeRunninOut)
                {
                    Controllers.Anim.TimeRunningOut();
                    timeRunninOut = true;
                }
            }
        }

    }

    public void LevelComplete()
    {
        stop = true;
    }
}

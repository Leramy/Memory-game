﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour, IGameManager
{
    [SerializeField] private Text timerText;

    public float timeStart;

    private bool timeRunninOut = false;
    public ManagerStatus status { get; private set; }
    public void Startup()
    {
        Debug.Log("Timer manager starting...");
        timerText.text = timeStart.ToString();

        status = ManagerStatus.Started;
    }

    void Update()
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
                Messenger.Broadcast(GameEvent.TIME_RUNNING_OUT);
                timeRunninOut = true;
            }
        }

    }
}

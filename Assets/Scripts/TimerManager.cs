using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour, IGameManager
{
    [SerializeField] private Text timerText;
    [SerializeField] private AnimationController anim;

    public float timeStart;

    private bool timeRunninOut = false;

    public bool stop;
    public ManagerStatus status { get; private set; }

    void Awake()
    {
        Messenger.AddListener(GameEvent.LEVEL_COMPLETE, LevelComplete);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.LEVEL_COMPLETE, LevelComplete);
    }

    public void Startup()
    {
        Debug.Log("Timer manager starting...");

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
                    anim.TimeRunningOut();
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

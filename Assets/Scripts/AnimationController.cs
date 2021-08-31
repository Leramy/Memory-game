using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Text timerText;
    void Awake()
    {
        Messenger.AddListener(GameEvent.TIME_RUNNING_OUT,TimeRunningOut);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.TIME_RUNNING_OUT, TimeRunningOut);
    }

    public void TimeRunningOut()
    {
        Animation timer = timerText.GetComponent<Animation>();
        timerText.color = Color.red;
        timer.Play("ScaleText");
    }
        
        
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private Image levelComplete;
    [SerializeField] private Image starLeft;
    [SerializeField] private Image starRight;
    [SerializeField] private Text NextText;
    void Awake()
    {
        Messenger.AddListener(GameEvent.TIME_RUNNING_OUT,TimeRunningOut);
        Messenger.AddListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.TIME_RUNNING_OUT, TimeRunningOut);
        Messenger.RemoveListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
    }

    public void TimeRunningOut()
    {
        Animation timer = timerText.GetComponent<Animation>();
        timerText.color = Color.red;
        timer.Play("ScaleText");
    }

    public void OnLevelComplete()
    {
        StartCoroutine(LevelComplete());
    }

    private IEnumerator LevelComplete()
    {
        Animation star_left = starLeft.GetComponent<Animation>();
        star_left.Play("StarLeft");

        yield return new WaitForSeconds(0.5f);

        Animation star_right = starRight.GetComponent<Animation>();
        star_right.Play("StarRight");

        yield return new WaitForSeconds(0.5f);

        Animation level = levelComplete.GetComponent<Animation>();
        level.Play("Level");

        yield return new WaitForSeconds(0.7f);

        NextText.gameObject.SetActive(true);
    }


}

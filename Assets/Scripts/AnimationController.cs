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

    [SerializeField] private Text timeUp;
    [SerializeField] private Text PlayAgainText;

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

    public void TimeUp()
    {
        Debug.Log("Here");
        StartCoroutine(TimeUpCoroutine());
    }

    private IEnumerator TimeUpCoroutine()
    {
        Animation timeUpAnim = timeUp.GetComponent<Animation>();
        timeUpAnim.Play("TimeUp");

        yield return new WaitForSeconds(2f);

        timeUpAnim.Stop();

        PlayAgainText.gameObject.SetActive(true);
    }
}

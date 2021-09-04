using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneController))]
[RequireComponent(typeof(AnimationController))]
[RequireComponent(typeof(UIController))]
[RequireComponent(typeof(TimerController))]
[RequireComponent(typeof(AudioController))]
public class Controllers : MonoBehaviour
{
    public static SceneController Scene { get; private set; }
    public static AnimationController Anim { get; private set; }
    public static UIController UI { get; private set; }
    public static TimerController Timer { get; private set; }
    public static AudioController Audio { get; private set; }

    private List<IGameController> _startSequence;
    private void Awake()
    {
        Scene = GetComponent<SceneController>();
        UI = GetComponent<UIController>();
        Timer = GetComponent<TimerController>();
        Anim= GetComponent<AnimationController>();
        Audio = GetComponent<AudioController>();

        _startSequence = new List<IGameController>();

        _startSequence.Add(Audio);
        _startSequence.Add(Timer);
        _startSequence.Add(UI);
        _startSequence.Add(Scene);
        _startSequence.Add(Anim);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {

        foreach (IGameController controller in _startSequence)
            controller.Startup();

        yield return null;

        int numModules = _startSequence.Count;
        int numReady = 0;

        while (numReady < numModules)
        {
            int LastReady = numReady;
            numReady = 0;

            foreach (IGameController controller in _startSequence)
            {
                if (controller.status == ManagerStatus.Started)
                    numReady++;
            }

            if (numReady > LastReady)
                Debug.Log("Progress: " + numReady + "/" + numModules);
            yield return null;
        }

        Debug.Log("All controllers started up");
    }
}

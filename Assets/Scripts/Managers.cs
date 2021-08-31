using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioManager))]
[RequireComponent(typeof(TimerManager))]

public class Managers : MonoBehaviour
{
    public static AudioManager Audio { get; private set; }
    public static TimerManager Timer { get; private set; }

    private List<IGameManager> _startSequence;

    private void Awake()
    {
        Audio = GetComponent<AudioManager>();
        Timer = GetComponent<TimerManager>();


        _startSequence = new List<IGameManager>();
        _startSequence.Add(Audio);
        _startSequence.Add(Timer);

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        
        foreach (IGameManager manager in _startSequence)
            manager.Startup();

        yield return null;

        int numModules = _startSequence.Count;
        int numReady = 0;

        while (numReady < numModules)
        {
            int LastReady = numReady;
            numReady = 0;

            foreach (IGameManager manager in _startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                    numReady++;
            }

            if (numReady > LastReady)
                Debug.Log("Progress: " + numReady + "/" + numModules);
            yield return null;
        }

        Debug.Log("All managers started up");
    }
}

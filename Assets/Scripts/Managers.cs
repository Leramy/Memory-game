using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LevelManager))]

public class Managers : MonoBehaviour
{
    public static LevelManager Level { get; private set; }

    private List<IGameManager> _startSequence;

    private void Awake()
    {
        Level = GetComponent<LevelManager>();

        _startSequence = new List<IGameManager>();

        _startSequence.Add(Level);

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

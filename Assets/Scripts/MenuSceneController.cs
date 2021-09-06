using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneController : MonoBehaviour
{
    public static AudioController Audio { get; private set; }

    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private ContinueUI continueUI;

    private void Awake()
    {
        Debug.Log("MenuSceneController started...");
        continueUI.Close();

        Audio = GetComponent<AudioController>();

        Audio.Startup();

        Audio.PlayMusic(menuMusic);

        
    }
}

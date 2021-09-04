﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour, IGameController
{
    public ManagerStatus status { get; private set; }

    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;

    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Sprite[] images;

    [SerializeField] private AudioSource soundSource;

    [SerializeField] private AudioClip MatchSound;
    [SerializeField] private AudioClip LevelMusic;

    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;

    private int _score = 0;

    private int max_score = 4;

    void Awake()
    {
        Messenger.AddListener(GameEvent.RESTART, Restart);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.RESTART, Restart);
    }

    public bool canReveal
    {
        get { return _secondRevealed == null; } 
    }

    public void Startup()
    {
        Debug.Log("SceneController started...");

        Vector3 startPos = originalCard.transform.position;

        Controllers.Audio.PlayMusic(LevelMusic);

        Debug.Log("Here");

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 }; 
        numbers = ShuffleArray(numbers);


        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MemoryCard;
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }

       
        status = ManagerStatus.Started;
    }

    private int[] ShuffleArray(int[] numbers)
    { 
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    public void CardRevealed(MemoryCard card)
    {
        if (_firstRevealed == null)
        { 
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;

            Controllers.Audio.PlaySound(MatchSound);
            Messenger.Broadcast(GameEvent.SCORE_CHANGED);

            if (_score == max_score)
            {
                Controllers.Timer.LevelComplete();
                Messenger.Broadcast(GameEvent.LEVEL_COMPLETE);
            }
        }
        else
        {
            yield return new WaitForSeconds(.15f);
            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null; 
        _secondRevealed = null;
    }


    public void Restart()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single); 
        
    }
}



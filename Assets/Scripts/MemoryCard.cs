using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;
    [SerializeField] private SceneController controller;
    [SerializeField] private SettingPopup popup;

    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip ClickSound;
   

    private int _id;

    public int id
    {
        get { return _id; }
    }

    public void SetCard(int id, Sprite image)
    { 
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image; 
    }
    public void OnMouseDown()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            if (cardBack.activeSelf)
            {
                cardBack.SetActive(false);
                soundSource.PlayOneShot(ClickSound);
                controller.CardRevealed(this);
            }
        }
            
    }

    public void Unreveal()
    { 
        cardBack.SetActive(true);
    }
}

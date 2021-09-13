using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;

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
        
        if(!IsPointerOverUIObject())
        {
            if (cardBack.activeSelf)
            {
                cardBack.SetActive(false);
                soundSource.PlayOneShot(ClickSound);
                Controllers.Scene.CardRevealed(this);
            }
        }
   
    }

    public void Unreveal()
    { 
        cardBack.SetActive(true);
    }

    //public static bool IsPointerOverGameObject()
    //{
    //    // Check mouse
    //    if (EventSystem.current.IsPointerOverGameObject())
    //    {
    //        return true;
    //    }

    //    // Check touches
    //    for (int i = 0; i < Input.touchCount; i++)
    //    {
    //        var touch = Input.GetTouch(i);
    //        if (touch.phase == TouchPhase.Began)
    //        {
    //            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
    //            {
    //                return true;
    //            }
    //        }
    //    }

    //    return false;
    //}


    private static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
#if !ANDROID
        eventDataCurrentPosition.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
#else
        eventDataCurrentPosition.position = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
#endif
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

}

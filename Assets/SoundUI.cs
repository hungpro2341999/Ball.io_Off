using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundUI : MonoBehaviour,IPointerClickHandler
{
    public AudioSource Audio;
    public GameObject m_Audio;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (Audio != null)
        {
            if (DataMananger.Instance.Is_Mute() == 1)
            {
                Audio.Play();
            }
        }
        else
        {
            if (DataMananger.Instance.Is_Mute() == 1)
            {
                m_Audio.GetComponent<AudioSource>().Play();
            }
               
        }
       
      
    }

}

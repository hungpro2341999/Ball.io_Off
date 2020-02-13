using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InforMap : MonoBehaviour
{
    
    public float Radius;
    public float Radian;
    public float Ground;
    public Vector3 Vertice;
    public float RateTime;
    float time;
    float timeCurr=0;
    public float offsetLevel;
    int count = 0;
    bool complete = false;
    public GameObject Img_Warring;
    float warringTime;
    int farme = 0;
    public Text CountTime;
    public float Speed =1;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 1;
        timeCurr = 10;
        RateTime = 10;
        warringTime = RateTime*0.35f;

      //  time = RateTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (GamePlayerCtrl.isPlayingGame)
        {
            Setting_Level();
        }
        else
        {
            VisibleCountTime(false);
        }
       
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
    public void Setting_Level()
    {
        VisibleCountTime(true);
        if (!complete)
        {
            if (timeCurr < 0)
            {
                timeCurr = RateTime;
                StartCoroutine(Redution_Map(0.1f));
                count++;
                if (count > 7)
                {
                    complete = true;
                }
            }
            else
            {
                
                timeCurr -= Time.deltaTime;
                if (Img_Warring != null)
                {
                    if (timeCurr < warringTime)
                    {
                        if (farme % 10 == 0)
                        {
                            Warring(!Img_Warring.active);
                        }
                       
                        farme++;
                        
                    }
                    else
                    {
                        Warring(false);
                        farme++;
                    }
                  
                }
               
            }
        }
        else
        {
            Warring(false);
        }
       
    }
    public IEnumerator Redution_Map(float offset)
    {
        float target = transform.localScale.x -offset;
        while (transform.localScale.x >= target)
        {
            transform.localScale -= Vector3.right*Time.deltaTime*Speed;

            transform.localScale -= Vector3.forward*Time.deltaTime*Speed;

            yield return new WaitForSeconds(0);
        }

       
    }
   
    public void Warring(bool active)
    {
        Img_Warring.SetActive(active);
    }
    public void VisibleCountTime(bool active)
    {
        if (CountTime != null)
        {
            if (active)
            {
                CountTime.text = ((int)timeCurr).ToString();
            }
            else
            {
                CountTime.text = "";
            }
        }
      
      
    }

}

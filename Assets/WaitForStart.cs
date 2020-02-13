using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitForStart : MonoBehaviour
{
    public GameObject Start_Game;
    public string[] List = new string[5] { "1", "2", "3", "START","PLAY"};
  
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
        GamePlayerCtrl.Instance.Event_Over_Game += Reset;
    }
    public void Reset()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Start_Waitting() 
    {
        for(int i = 0; i < List.Length; i++)
        {
        //    Debug.Log("LENGTH : " +i);
            StartCoroutine(EnableString(i,i));
        }
      
    }

    public IEnumerator EnableString(float time,int i)
    {

         
       
            yield return new WaitForSeconds(time);
            text.text = List[i];
            if (i == 3)
            {
         
            StartCoroutine(Play(1));
            Instantiate(Start_Game, null);
            }

      
        
       

    }
    public IEnumerator Play(float time)
    {
        
        yield return new WaitForSeconds(time);
        DataMananger.Instance.PlayAudio("sfx_ready", Vector3.zero);
        GamePlayerCtrl.Instance.Status = StatusGame.Play;
        GamePlayerCtrl.Instance.isGameOver = false;
        GamePlayerCtrl.Instance.isGamePause = false;
        GamePlayerCtrl.Instance.Init_Infor();
        text.text = "";
        gameObject.SetActive(false);
        GamePlayerCtrl.isPlayingGame = true;

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windown : MonoBehaviour
{
    
    public Windown_Type type;
    public Animator Anim;
    bool Open_Anim = false;
    public Text Coin;
  
    // Start is called before the first frame update
    void Start()
    {
      
    }
    IEnumerator BackToStartScreen()
    {

        yield return new WaitForSeconds(3);
        GamePlayerCtrl.Instance.Event_Over_Game();
        GameMangaer.Instance.Open_Screen(Screen_Type.Screen_Start);
        Close();
        Debug.Log("Back To Screen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
     
        gameObject.SetActive(true);
        if (Anim != null)
        {
            Open_Anim = !Open_Anim;
            Anim.SetBool("Open", Open_Anim);

            if (type == Windown_Type.Shop)
            {
                gameObject.GetComponentInParent<Animator>().SetBool("Open", true);
            }
            if (type == Windown_Type.End_Game)
            {
                DataMananger.Instance.PlayAudio("end_game", Vector3.zero);
                StartCoroutine(BackToStartScreen());
            }
            else if (type == Windown_Type.Game_Over)
            {
                //   Cricle.Wait_Over_Game = true;
                StartCoroutine(Start_Add_Coin(1));
            }

        }
        else
        {
            if (type == Windown_Type.Shop)
            {
                gameObject.GetComponentInParent<Animator>().SetBool("Open", true);
            }
            if (type == Windown_Type.End_Game)
            {
              //  StartCoroutine(BackToStartScreen());
            
                
            }
            else if (type == Windown_Type.Game_Over)
            {
               
                
            }
        }
       
        
    }
    public void Close()
    {
        gameObject.SetActive(false);
       
    }
    IEnumerator Start_Add_Coin(int amount)
    {
        int targetCoin = RollBall.Coin;
        while(int.Parse(Coin.text)==targetCoin)
        yield return new WaitForSeconds(0);
        int coin = int.Parse(Coin.text);
        coin += amount;
        coin = Mathf.Clamp(coin,0, targetCoin);
        Coin.text = coin.ToString();
    }
   
  
}

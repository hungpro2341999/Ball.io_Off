using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Image Victory;
    public Image Defends;
    public Windown Over_game;
    public Windown Result_game;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Result_Match()
    {
        bool isVictory = false;
        if (GamePlayerCtrl.Instance.Main_Player == null)
        {
            return;
        }
        if (GamePlayerCtrl.Instance.Main_Player.GetComponent<Enemy>().isGround)
        {
            isVictory = true;
        }
        else
        {
            isVictory = false;
        }
        GamePlayerCtrl.isPlayerWin = isVictory;
        if (isVictory)
        {
            Victory.gameObject.SetActive(true);
            Defends.gameObject.SetActive(false);
            
            Invoke("OpenGameOver", 2.5f);
          
        }
        else
        {
            Victory.gameObject.SetActive(false);
            Defends.gameObject.SetActive(true);
            Invoke("OpenGameOver", 2.5f);
        }
    }
    public void OpenGameOver()
    {
        Over_game.Open();
        Result_game.Close();

    }
    
}

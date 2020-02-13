using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Windown_Type {Start,Shop,Setting,Quest,Play,Revice,Game_Over,Rank,End_Game,Wait_For_Start,Watching}
public enum Screen_Type {Screen_Start,Screen_Play,Screen_loading}

public class Mutiply_Screen : MonoBehaviour
{
    public Animator anim;
    public Screen_Type Type_Screen;
    public List<Windown> Windows;
    public InputField input_Name;
    public Animator Setting;
    //   public BotNameData botnameData;

    // Start is called before the first frame update
    private void Awake()
    {

        switch (Type_Screen)
        {
            case Screen_Type.Screen_Start:
                 input_Name.text = DataMananger.Instance.Get_Name_Player();
                 CloseAll(Windown_Type.Start);
                GamePlayerCtrl.Instance.Event_Over_Game += End_Game_Start;
                break;
            case Screen_Type.Screen_Play:

                CloseAll(Windown_Type.Play);
                GamePlayerCtrl.Instance.Event_Over_Game += End_Game_Play;
                break;
            case Screen_Type.Screen_loading:


                break;
        }
    }
    void Start()
    {
       
       
    }
    public void Change_Name() 
    {
        string name = input_Name.text;
        DataMananger.Instance.Set_Name_Player(name);
     
       var a =    Instantiate(SpawnEffect.Instance.getEffectName("Status"), null);
        a.GetComponent<Status>().SetText("CHANGE COMPLETE");

    }
    public void End_Game_Start() 
    
    {
        CloseAll(Windown_Type.Start);
    }
    public void End_Game_Play()

    {
        CloseAll(Windown_Type.Play);
    }

    // Update is called once per frame
    public  void CloseAll(Windown_Type type)
    {
        foreach(Windown w in Windows)
        {
           if(w.type == type)
            {
                w.Open();
            }
            else
            {
                w.Close();
            }
        }
    }

   

    void Update()
    {


    }

    public void Open_Screen()
    {
        if (anim != null)
        {
            anim.SetBool("Open", true);
        }
        else
        {
            gameObject.SetActive(true);
        }
      
      
    }
    public void Close_Screen()
    {
        if (anim != null)
        {
            anim.SetBool("Open", false);
            if(Type_Screen == Screen_Type.Screen_Start)
            {
                Setting.SetBool("Open", false);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    public void OpenWindow(Windown windown)
    {
        foreach(Windown w in Windows)
        {
            if(w.type == windown.type)
            {
             
                windown.Open();
                
            }
            else
            {
                Debug.Log("Close");
                w.Close();
            }


        }
    }
    public void OpenWindow(Windown_Type windown)
    {
        foreach (Windown w in Windows)
        {
            if (w.type == windown)
            {
             
                w.Open();
            }
          
        }
    }

    
    public void CloseWindow(Windown windown)
    {
        foreach (Windown w in Windows)
        {
            if (w.type == windown.type)
            {
                w.Close();
            }
            else
            {
                w.Open();
            }
        }
    }
    public void CloseWindow(Windown_Type windown)
    {
        foreach (Windown w in Windows)
        {
            if (w.type == windown)
            {
                w.Close();
            }
        }
    }


}

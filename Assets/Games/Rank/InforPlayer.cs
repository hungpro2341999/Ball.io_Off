    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InforPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite Sprite_Flag;
    public string namePlayer ="";
   
    void Start()
    {
     
    }

    // Update is called once per frame
    public void SetInfor()
    {
       if( gameObject.tag != "Player")
        {
            DataMananger.Instance.Push_Infor(this);
        }
        else
        {
            namePlayer = DataMananger.Instance.Get_Name_Player();
        }
       
           
          
       
      
       
    }
    public void set_Infor_Player()
    {
       
    }
    void Update()
    {
      
    }
}

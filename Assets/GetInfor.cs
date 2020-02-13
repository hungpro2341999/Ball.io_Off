using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInfor : MonoBehaviour
{
   public  Player player;
    public Text Name;
    public Image Flag;
    public float OffSet;
    public Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(player.transform.position + Vector3.up * OffSet);
            var a = player.GetComponent<Enemy>();
            if (a != null)
            {
                //    text.text = "Velocity: "+a.body.velocity.magnitude + "\n" + "Force : "+a.ForceIntertion +"\n" + "MoveBack : " + a.isMoveBack;
            }
        }
        else
        {
            Destroy();
        }
           

        

    }

    public void Get_Infor_Player()
    {
        Name.text = player.GetComponent<InforPlayer>().namePlayer;
    }
    public void GetData()
    {
        
        Flag.sprite = player.GetComponent<InforPlayer>().Sprite_Flag;
        Name.text = player.GetComponent<InforPlayer>().namePlayer;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

}

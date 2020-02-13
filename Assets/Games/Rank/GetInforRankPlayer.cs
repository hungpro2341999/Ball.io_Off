using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInforRankPlayer : MonoBehaviour
{

    public Image spriteFlag;
    public Text nameBot;
    public InforPlayer infor;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.name);
        spriteFlag.sprite = infor.Sprite_Flag;
        nameBot.text = infor.namePlayer;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleInforPlayer : MonoBehaviour
{

    public GameObject VisibleInfor;
    public Transform Parent;
    public List<GameObject> list = new List<GameObject>();

    // Start is called before the first frame update
    private void Awake()
    {
       
    }
    void Start()
    {
        
        GamePlayerCtrl.Instance.Event_Over_Game += DestroyAll;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void Init()
    {
      
        for (int i = 0; i < GamePlayerCtrl.Instance.player.Length; i++)
        {
           
            var a =  Instantiate(VisibleInfor, Parent);
            if (GamePlayerCtrl.Instance.player[i].tag!="Player")
            {
                a.GetComponent<GetInfor>().player = GamePlayerCtrl.Instance.player[i];

                a.GetComponent<GetInfor>().GetData();
                
            }
            else
            {
                a.GetComponent<GetInfor>().player = GamePlayerCtrl.Instance.Main_Player;
                a.GetComponent<GetInfor>().Get_Infor_Player();
            }
            list.Add(a);

        }
    }
    public void DestroyAll()
    {
        if (list != null)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                {
                    list[i].GetComponent<GetInfor>().Destroy();
                }
               
            }
        }
       
    }
}

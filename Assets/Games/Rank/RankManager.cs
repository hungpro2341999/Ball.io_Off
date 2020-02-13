using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    public GameObject Obj_rank;
    Player[] player;
    public Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        player = GamePlayerCtrl.Instance.player;
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init()
    {
        for(int i = 0; i < player.Length ; i++)
        {
            var a = Instantiate(Obj_rank, parent);
            a.GetComponent<GetInforRankPlayer>().infor = player[i].GetComponent<InforPlayer>();


        }
    }
}

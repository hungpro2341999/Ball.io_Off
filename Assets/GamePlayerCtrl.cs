using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusGame { Play,Pause,Out_Game,Wait,Reset,Game_Over,Watching,End_Game,None,Back_To_Game,Not_Connect_Internet}
public class GamePlayerCtrl : MonoBehaviour
{
   
    public static GamePlayerCtrl Instance;
    public Transform WaitForStart;
    public Mutiply_Screen Windown;
    public VisibleInforPlayer visible;
    public StatusGame Status = StatusGame.Wait;
    public GameObject AI;
    public GameObject Player;
    public Player[] player;
    public Player Main_Player;
    public float Radius;
    public float OffSet;
    public float Ground;
    public float Count_Player = 5;
    public Transform Parent;
    public bool isGameOver = false;
    public bool isGamePause = false;
    public bool isWinGame = false;
    public delegate void Event_Game();
    public LayerMask MaskPlayer;
    public LayerMask GroundLayer;
    public Event_Game Event_Reset_Game;
    public static bool  connect = true;
    public static bool isPlayingGame = false;
    public static bool isPlayerWin = false;

    public Event_Game Event_Over_Game;
   // public Event_Game Event_Back_To_Screen_Game;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        Event_Reset_Game += Start_Game;
        Event_Reset_Game += Play;
        Event_Over_Game += GameOver;
        Event_Over_Game += NotPlay;
    }

    public void GameOver()
    {
        DestroyAll();
        isPlayerWin = false;
        player = null;
        Main_Player = null;
         isPlayerWin = false;

}


public int CountPlayer()
    {
        return player.Length;
    }

    // Start is called before the first frame update
    void Start()
    {
        
      
    }
    void Update()
    {

        
       
    }
    public void Play()
    {
        isPlayerWin = false;

      //  isPlayingGame = true;
    }
    public void NotPlay()
    {
        isPlayingGame = false;
    }

    public void EndGame()
    {
        isGameOver = true;
        isGamePause = true;
        Status = StatusGame.None;
        for(int i = 0; i < player.Length; i++)
        {
            player[i].GetComponent<Enemy>().Destroy();
        }
    }
    public void Incre_Radius()
    {
        for (int i = 0; i < player.Length; i++)
        {
            try
            {
                if (Random.Range(0, 2) != 1)
                {
                    if (DataMananger.MapSelec != 3 || DataMananger.MapSelec != 4)
                    {
                        player[i].GetComponent<Enemy>().Radius += Random.Range(0.1f, 0.5f);
                    }
                   
                }
               
            }
            catch (System.Exception)
            {
                Debug.Log("Null AI");
                throw;
            }
          
            
        }
        Debug.Log("5");
    }
    private void FixedUpdate()
    {
       
     
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            if (isPlayingGame)
            {
                if (connect)
                {
                    connect = false;
                    Windown.OpenWindow(Windown_Type.End_Game);
                    GamePlayerCtrl.Instance.Event_Over_Game();
                    Stop_All_Player();
                    GameMangaer.Instance.Open_Screen(Screen_Type.Screen_Start);
                    var a = Instantiate(SpawnEffect.Instance.getEffectName("Status"), null);
                    a.GetComponent<Status>().SetText("YOU ARE DISCONNECTED INTERNET  !!!");
                }
            }
           
                

        }
        else
        {
            connect = true;
            if (Status == StatusGame.Back_To_Game)
            {
                GamePlayerCtrl.Instance.Event_Over_Game();
                GameMangaer.Instance.Open_Screen(Screen_Type.Screen_Start);
                Status = StatusGame.None;

            }
            if (Status == StatusGame.Out_Game)
            {
                if (Is_End_Game())
                {

                    Status = StatusGame.End_Game;
                    Debug.Log("END_GAME");
                    Windown.CloseWindow(Windown_Type.End_Game);
                }
            }

            if (Status == StatusGame.Play)
            {

                if (Is_Game_OVer())
                {
                    Status = StatusGame.End_Game;
                    Debug.Log("GameOVer");
                    //Windown.OpenWindow(Windown_Type.Game_Over);
                    Windown.CloseWindow(Windown_Type.End_Game);

                }
                if (Is_End_Game())
                {
                    Status = StatusGame.End_Game;
                    Debug.Log("END_GAME");
                    Windown.CloseWindow(Windown_Type.End_Game);
                    
                }
            }
            if (Status == StatusGame.Watching)
            {
                if (isGameOver)
                {
                    Windown.CloseWindow(Windown_Type.Game_Over);
                    Windown.OpenWindow(Windown_Type.Watching);
                }
                Status = StatusGame.Out_Game;
            }
            if (Status == StatusGame.End_Game)
            {
                Windown.OpenWindow(Windown_Type.End_Game);
                Status = StatusGame.None;

            }
        }


        
            
    }

    public void Start_Game()
    {
        WaitForStart.gameObject.SetActive(true);
        Status = StatusGame.Wait;
        DestroyAll();
        InforMap inforMap = GameObject.Find("Map").GetComponent<InforMap>();
        Radius = inforMap.Radius;
        Ground = inforMap.Ground;
        Count_Player = DataMananger.Instance.CountPlayer;
        WaitForStart.GetComponent<WaitForStart>().Start_Waitting();
        Reset_Game();
       

    }
    
    public bool Is_Game_OVer()
    {
        if (Main_Player != null)
        {
            if (!Main_Player.GetComponent<Enemy>().isGround)
            {
                int count = 0;
                for (int i = 0; i < player.Length; i++)
                {
                    if (player[i].GetComponent<Enemy>().isGround)
                    {
                        Debug.Log(player[i].name + " " + "Out");
                        count++;
                    }
                }
                if (count != 1)
                {
                    isGameOver = true;
                }
                else
                {
                    isGameOver = false;
                    Status = StatusGame.End_Game;
                }
             

            }
            else
            {
                
                isGameOver = false;
                // 
            }
            return isGameOver;
        }
       return false;
       
    }

    public bool Is_End_Game()
    {
        if (player != null)
        {
            int indexPlayer = 0;
            bool isWin = false;
            int count = 0;
            for (int i = 0; i < player.Length; i++)
            {
                if (player[i].GetComponent<Enemy>().isGround)
                {
                    indexPlayer = i;
                  //  Debug.Log(player[i].name + " " + "Out");
                    count++;
                }
            }
            if (count <= 1)
            {
                isWin = true;
                if (Main_Player.GetComponent<Enemy>().isGround)
                {
                    VicTory();
                }
            }

            return isWin;
        }
        else 
        {
            return true;
        }
       
    }
   

    public void InitGame()
    {
        
        player = GameObject.FindObjectsOfType<Player>();
        Debug.Log("COUNT :" + player.Length);
        for (int i = 0; i < player.Length; i++)
        {
            if(player[i].name  == "Player" || player[i].tag == "Player")
            {
                Main_Player = player[i];
                MoveFlowPlayer.Instance.player = Main_Player;

            }
            else
            {
                
            //    Debug.Log("REMOVE : "+i +"     "+ player[i].name);
            }
            
        }
        for (int i = 0; i < player.Length; i++)
        {
            player[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            player[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            player[i].GetComponent<Rigidbody>().isKinematic = false;
            player[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }


    }

    // Update is called once per frame
    

    public Player getEneMyNearst(Player player)
    {
        if (this.player.Length > 1)
        {
            Player target = null;
            Vector3 pos = player.transform.position;
            float distance = Mathf.Infinity;
            for (int i = 0; i < this.player.Length; i++)
            {
                if (this.player[i].gameObject.name != player.gameObject.name)
                {
                    if (Vector3.Distance(pos, this.player[i].transform.position) < distance)
                    {
                        distance = Vector3.Distance(pos, this.player[i].transform.position);

                        target = this.player[i];
                    }
                }

            }
            //   Debug.Log(player.name + ": Target : " + target.name);

            //   Debug.DrawLine(player.transform.position, target.transform.position, Color.red);
            return target;
        }
        else
        {
            Debug.Log("You Alone");
            return null;
        }

    }
    
    public Player getPlayer(int index)
    {
        return this.player[index];
    }
    public void DestroyAll()
    {
       Enemy[] player = GameObject.FindObjectsOfType<Enemy>();
        for(int i = 0; i < player.Length; i++)
        {
          //  Debug.Log("NAME : " +player[i].name);
            player[i].GetComponent<Enemy>().Destroy();
            player[i].gameObject.SetActive(false);
        }
        
            
        

    }
    public void Stop_All_Player()
    {
        //for (int i = 0; i < player.Length; i++)
        //{
        //    //if (player[i] != null)
        //    //{
        //    //    player[i].GetComponent<Rigidbody>().isKinematic = true;
        //    //    player[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
        //    //    player[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //    //}
           
           
        //}
    }
    public void Reset_Game()
    {
        bool Accpect1 = false;
        while (!Accpect1)
        {
            Vector3 pos = Random.insideUnitCircle * Radius;
            pos = new Vector3(pos.x, Ground + OffSet, pos.y);
            if (Physics.SphereCast(new Ray(pos, transform.up),0.35f, 0,MaskPlayer) || !Physics.Raycast(new Ray(pos, -Vector3.up), 100,GroundLayer))
            {
                Accpect1 = false;
            }
            else
            {
               
               
                var a1 = Instantiate(Player, pos, Quaternion.identity, Parent);
                a1.name = "Player";
                
                a1.GetComponent<InforPlayer>().SetInfor();
                Accpect1 = true;
                Main_Player = a1.GetComponent<Player>();

            }
        }

        for (int i=0; i<Count_Player; i++)
        {
           StartCoroutine(Spawn_Player(Random.Range(0,2),i));
                 
        }
      

    }
    public IEnumerator Spawn_Player(float time,int i)
    {
        yield return new WaitForSeconds(time);
        bool Accpect = false;
        while (!Accpect)
        {
          
            Vector3 pos = Random.insideUnitCircle * Radius;
            pos = new Vector3(pos.x, Ground + OffSet, pos.y);
            if (Physics.SphereCastAll(new Ray(pos, transform.up), 0.35f, 0, MaskPlayer).Length==0)
            {
                Debug.Log("OK");
                var a = Instantiate(AI, pos, Quaternion.identity, Parent);

                a.name = "AI_" + i;

               
                //Debug.Log(a.name + " " + a.GetComponent<Enemy>().GetEnemyInRadius(2f,pos,transform.up));
                if(a.GetComponent<Enemy>().GetEnemyInRadius(0.2f, pos, transform.up) != 0 || !Physics.Raycast(new Ray(pos, -Vector3.up),100,GroundLayer))
                {
                    Accpect = false;
                    a.GetComponent<Enemy>().Destroy();
                }
                else
                {
                    a.GetComponent<InforPlayer>().SetInfor();
                    Accpect = true;
                }
                //   StartCoroutine(Spawn_Player(Time.fixedDeltaTime * 3 * i, pos, i));

               

            }
            else
            {
                Accpect = false;
                Debug.Log(" NOT OK :" + Physics.SphereCastAll(new Ray(pos, transform.up), 0.75f, 0, MaskPlayer).Length);

              //  yield return new WaitForSeconds(0);

            }
          //  Accpect = true;

        }
      
     
    }

    public void Claim()
    {
        if (!Is_End_Game())
        {
            Status = StatusGame.Watching;
        }
        else
        {
            var a = Instantiate(SpawnEffect.Instance.getEffectName("Status"), null);
            a.GetComponent<Status>().SetText("THE MATCH ENDED !!!");
        }
       
    }
    

    public void Init_Infor()
    {
        InitGame();
        visible.Init();

    }

    public void Back_To_Game()
    {
        ManagerAds.Ins.ShowInterstitial();
        Status = StatusGame.Back_To_Game;
    }
    public void VicTory()
    {
        RollBall.Coin = RollBall.Coin*2+110;
        DataMananger.Instance.Add_Coin(RollBall.Coin);
       // RollBall.Coin = 0;
    }


}

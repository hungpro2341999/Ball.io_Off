using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataMananger : MonoBehaviour
{
    public static DataMananger Instance = null;
    public static int MapSelec = -1;
    #region Data
    public Skill Data_Skills;
    public List<GameObject> Audio = new List<GameObject>();
    public BotNameData Data_Bot;
    public List<Process_Player> Data_List_Player = new List<Process_Player>();
    public List<Material> Material_Sky = new List<Material>();
    public int CountPlayer = 4;
    public int Coin;
    [SerializeField ]int index = 0;
    [SerializeField] int index_1 = 0;
    #endregion


    #region Key

    public const string Key_Sound = "Key_Sound";
    public const string Key_Variable = "Key_Var";
    public string Key_Shop = "Key_Shop";
    public const string Key_Coin = "Key_Coin";
  
    public const string Key_Model_Use = "Key_Model_Use";
    public const string Key_Name_Player = "Key_Name_Player";
   
    #endregion

    #region 

    public int IsMute = 1;
    public int IsVariable = 1;
    public int id_mode_Use = 0;
    #endregion

    #region Transform
    public Text m_Coin;
    public Transform Map;
   

    #endregion
    #region Option__Sound_Variable
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
        GamePlayerCtrl.Instance.Event_Over_Game += Reset;
        Init_Key();
    }

    private void Start()
    {
       
        Random_Sky();
        Random_Map();
        GamePlayerCtrl.Instance.Event_Over_Game += Random_Map;
        GamePlayerCtrl.Instance.Event_Over_Game += Random_Sky;
    }
    
    public void Init_Key()
    {
        if (!PlayerPrefs.HasKey(Key_Sound))
        {

            PlayerPrefs.SetInt(Key_Sound, 1);
            PlayerPrefs.Save();
        }
        else
        {
            IsMute = PlayerPrefs.GetInt(Key_Sound);
        }
        if (!PlayerPrefs.HasKey(Key_Variable))
        {

            PlayerPrefs.SetInt(Key_Variable, 1);
            PlayerPrefs.Save();
        }
        else
        {
            IsMute = PlayerPrefs.GetInt(Key_Sound);
        }

        //  INIT SHOP
        //   PlayerPrefs.DeleteKey(Key_Shop);
        if (!PlayerPrefs.HasKey(Key_Shop))
        {
          List<Infor_Skill> lists = new List<Infor_Skill>();

            for(int i = 0; i < Data_Skills.Images.Count; i++)
            {
                if (i != 0)
                {
                    Infor_Skill skill = new Infor_Skill(i, false, false,DataMananger.Instance.Data_Skills.Cost[i]);
                    lists.Add(skill);
                    

                }
                else
                {

                    Infor_Skill skill = new Infor_Skill(i, true, true, DataMananger.Instance.Data_Skills.Cost[i]);
                    lists.Add(skill);
                }
               
                    
            }


            List_Infor_Skill Save_list = new List_Infor_Skill(lists);
            string key =  JsonUtility.ToJson(Save_list);
            PlayerPrefs.SetString(Key_Shop, key);
            PlayerPrefs.Save();
            Data_Skills.List_infor_Skill = lists;
           
           List_Infor_Skill Save_list_1 = JsonUtility.FromJson<List_Infor_Skill>(PlayerPrefs.GetString(Key_Shop));
            Debug.Log("CO SKIN : " + Save_list_1.lists.Count);

        }
        else
        {
            List<Infor_Skill> list = JsonUtility.FromJson<List_Infor_Skill>(PlayerPrefs.GetString(Key_Shop)).lists;
            Debug.Log("CO SKIN : " + list.Count);
            Data_Skills.List_infor_Skill = list;
            Render();





        }

        //////////
        //////////
        ///

        //Init Coin
        //PlayerPrefs.DeleteKey(Key_Coin);
        if (!PlayerPrefs.HasKey(Key_Coin))
        {
            PlayerPrefs.SetInt(Key_Coin,0);
            PlayerPrefs.Save();
            //m_Coin.text = Get_Coin();
            Coin = PlayerPrefs.GetInt(Key_Coin);
            StartCoroutine(Start_Add_Coin(10));
        }
        else
        {
            Coin = PlayerPrefs.GetInt(Key_Coin);
            m_Coin.text = 0.ToString();
            StartCoroutine(Start_Add_Coin(10));

        }
        // Init Ball Player
       //  PlayerPrefs.DeleteKey(Key_Model_Use);
        if (!PlayerPrefs.HasKey(Key_Model_Use))
        {
            PlayerPrefs.SetInt(Key_Model_Use, 0);
            PlayerPrefs.Save();
        }
        {
            Debug.Log("SKIN : " +PlayerPrefs.GetInt(Key_Model_Use));
        }

        // Init_Name_Player
        if (!PlayerPrefs.HasKey(Key_Name_Player)) 
        {
            PlayerPrefs.SetString(Key_Name_Player, "");
            PlayerPrefs.Save();
        
        }
      
    }
    public void Set_Name_Player(string name) 
    {
        PlayerPrefs.SetString(Key_Name_Player, name);
        PlayerPrefs.Save();
    }
    public string Get_Name_Player() 
    {
        return PlayerPrefs.GetString(Key_Name_Player);
    }

    public void Set_Id_Skin_Use(int id)
    {
        PlayerPrefs.SetInt(Key_Model_Use, id);
        PlayerPrefs.Save();
    }
    public int Get_Id_Skin() 
    {
        
        return PlayerPrefs.GetInt(Key_Model_Use);
    
    }
  
    public GameObject getModel(int id)
    {
        return Data_Skills.ListModel[id];
    }



    public int Is_Mute()
    {
        return PlayerPrefs.GetInt(Key_Sound);
    }
    public void Save_On_Off_Sound(bool mute)
    {
        if (mute)
        {
            PlayerPrefs.SetInt(Key_Sound, 1);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt(Key_Sound, 0);
            PlayerPrefs.Save();
        }
        
    }
    public int Is_Variable()
    {
        return PlayerPrefs.GetInt(Key_Variable);
    }

    public void Save_On_Off_Variable(bool mute)
    {
        if (mute)
        {
            PlayerPrefs.SetInt(Key_Variable, 1);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt(Key_Variable, 0);
            PlayerPrefs.Save();
        }

    }
    #endregion

    public void Save_Coin(int coin)
    {
        PlayerPrefs.SetInt(Key_Coin, coin);
        PlayerPrefs.Save();
    }
    public string Get_Coin()
    {
      return  PlayerPrefs.GetInt(Key_Coin).ToString();
       
    }
    public int Get_Coin_Current()
    {
        return PlayerPrefs.GetInt(Key_Coin);

    }
    public void Add_Coin(int coin)
    {
        this.Coin += coin;
        Save_Coin(this.Coin);
       // m_Coin.text = Get_Coin();
        StartCoroutine(Start_Add_Coin(3));

    }
    public void Earn_Coin(int coin)
    {
        this.Coin -= coin;
        Save_Coin(this.Coin);
        //m_Coin.text = this.Coin.ToString();
        StartCoroutine(Start_Add_Coin(-10));
    }
    public void Set_Coin(int coin)
    {
        Save_Coin(coin);
    }
    public void Save_Shop(List<Infor_Skill> skills)
    {
        List_Infor_Skill Save = new List_Infor_Skill(skills);
        
        string key = JsonUtility.ToJson(Save);

        PlayerPrefs.SetString(Key_Shop, key);
        PlayerPrefs.Save();
        
    }
    public void Render()
    {
        List<Infor_Skill> list = JsonUtility.FromJson<List_Infor_Skill>(PlayerPrefs.GetString(Key_Shop)).lists;
        for(int i = 0;i< list.Count; i++)
        {
        //    Debug.Log(list[i].id + "   " + list[i].isBuy);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            DataMananger.Instance.PlayAudio("va2",new Vector3(0,50,0));
        }
    }
    public void Reset()
    {
        index_1 = 0;
        index = 0;
        Data_List_Player.Clear();
    }
    public void Push_Data(List<Process_Player> processes)
    {
        Data_List_Player = new List<Process_Player>();
        Data_List_Player = processes;
    }

   
    public Process_Player Set_Random_Infor()
    {
        Process_Player process_Player = new Process_Player();
        var a = Data_Bot.botNames[Random.Range(0, Data_Bot.botNames.Count)];

        var b = a.botName[Random.Range(0, a.botName.Count)];

       process_Player.sprite = a.icon;
       process_Player.name = b;
        return process_Player;
    }

    public Process_Player Set_Infor_Player()
    {
        Process_Player process_Player = new Process_Player();
        process_Player.name = DataMananger.Instance.Get_Name_Player();
        process_Player.sprite =  Data_Bot.botNames[Random.Range(0, Data_Bot.botNames.Count)].icon;
        return process_Player;
    }
    public void Push_Infor(GetInfor player)
    {
        Process_Player process = Data_List_Player[index];
        player.Flag.sprite = process.sprite;
        player.Name.text = process.name;

        index++;
        Debug.Log("index : " + process.name);

    }
    public void Push_Infor(InforPlayer player)
    {
        Process_Player process = Data_List_Player[index_1];

        player.Sprite_Flag = process.sprite;
        player.namePlayer = process.name;
        
        index_1++;
      

    }
    public void Random_Map()
    {
         var map_1 = GameObject.Find("Map");
        if (map_1 != null)
        {
            map_1.GetComponent<InforMap>().Destroy();
        }
        else
        {
            
        }
        int r = Random.Range(0, Data_Skills.Maps.Count);
        var map = Data_Skills.Maps[r].GetComponent<Map>();
        MapSelec = r;
        var a = Instantiate(map.Shape, Vector3.zero, Quaternion.identity,Map);
        int index_material = Random.Range(0, map.Surface.Count);
        Transform[] shape = a.GetComponent<Transform>().Find("Shape").GetComponentsInChildren<Transform>();
        Debug.Log("Shape : " + shape.Length);
        for(int i = 0; i < shape.Length; i++)
        {
        if(shape[i].name == "Shape" && shape[i].GetComponent<Renderer>()!=null)
            {
                shape[i].GetComponent<Renderer>().material = map.Surface[index_material];
            }
        }
         //a.GetComponents<Transform>().Find("Shape").GetComponent<Renderer>().material = map.Surface[Random.Range(0, map.Surface.Count)];
        a.name = "Map";
    }
   
    public void Random_Sky()
    {
        Debug.Log("Sky_Random");
        int r = Random.Range(0, Data_Skills.Sprite_Sky.Count-1);
        var a = Data_Skills.Sprite_Sky[r];
        RenderSettings.skybox = a;

    }
    public void Check()
    {

        Debug.Log("Change");
    }
    public IEnumerator Start_Add_Coin(int count)
    {
        int coinCurr = int.Parse(DataMananger.Instance.Get_Coin());
        while (int.Parse(m_Coin.text)!= coinCurr)
        {
            if (Mathf.Sign(count) != -1)
            {
                int Coin = int.Parse(m_Coin.text) + count;
                Coin = (int)Mathf.Clamp(Coin, 0, int.Parse(DataMananger.Instance.Get_Coin()));
                m_Coin.text = Coin.ToString();
                yield return new WaitForSeconds(0);
            }
            else 
            {
                Coin = (int)Mathf.Clamp(Coin, 0, int.Parse(DataMananger.Instance.Get_Coin()));
                m_Coin.text = Coin.ToString();
                yield return new WaitForSeconds(0);
            }
           
        }
    }
    public void PlayAudio(string name,Vector3 pos)
    {
        for(int i = 0; i < Audio.Count; i++)
        {
           
            if(Audio[i].name == name)
            {
                if (DataMananger.Instance.Is_Mute() == 1)
                {
                    Vector3 vec = Camera.main.transform.position;
                    Debug.Log("Play :"+name);
                    var a =  Instantiate(Audio[i],pos,Quaternion.identity,null);
                    a.GetComponent<AudioSource>().Play();
                    a.AddComponent<DestroyAudio>();
                    
                    //Audio[i].Play();
                }
            }
         
        }
    }
   
    
}

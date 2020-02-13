using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading_Screen : MonoBehaviour
{
    public GameObject Flag;
    public Transform Parent;
    public List<GameObject> list = new List<GameObject>();
    public List<Process_Player> list_Process = new List<Process_Player>();
    
    public int numberPlayer;
   
    public List<int> Loaded;
    public float WaitTime = 3;
    public bool isComplete = false;
    int Max;
    // Start is called before the first frame update
    private void Awake()
    {
        GamePlayerCtrl.Instance.Event_Over_Game += GameOver;
    }
    void Start()
    {
      Max = numberPlayer;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
           var a =  Instantiate(SpawnEffect.Instance.getEffectName("Score"), null);
            a.GetComponent<Destroy>().SetPosText(Vector3.zero);
        }
    }

    public void GameOver()
    {
       
     for(int i = 0; i < list.Count; i++)
        {
            list[i].GetComponent<LoadInfor>().Destroy();
        }
        Loaded = new List<int>();
        list = new List<GameObject>();
        list_Process = new List<Process_Player>();
        isComplete = false;
        
    }
    public void StartProcess()
    {
        bool first = true;
        if (/*Application.internetReachability != NetworkReachability.NotReachable*/1==1)
        {


            numberPlayer = Random.Range(7,12);
        for (int i = 0; i < numberPlayer; i++) // +1 for player
        {
            var a = Instantiate(Flag, Parent);
            list.Add(a);

        }

        for (int i = 0; i < list.Count; i++)
        {
                Debug.Log("Index : " + i);
            bool isLoaded = false;

            while (!isLoaded)
            {
                    if (!first)
                    {
                        int index = Random.Range(0, numberPlayer);
                        Debug.Log("INDEX : " + index);
                        if (Loaded.Contains(index))
                        {
                            continue;
                        }
                        else
                        {
                            isLoaded = true;
                            Loaded.Add(index);
                            if (i == numberPlayer-1)
                            {
                                StartCoroutine(Process_Loading(index, list[index], Random.Range(0, WaitTime), true, false));
                            }
                            else
                            {
                                StartCoroutine(Process_Loading(index, list[index], Random.Range(0, WaitTime), false, false));
                            }

                        }
                    }
                    else
                    {
                        first = false;
                        int index = Random.Range(0, numberPlayer);
                        isLoaded = true;
                        Loaded.Add(index);
                        StartCoroutine(Process_Loading(index, list[index], Random.Range(0, WaitTime),false,true));
                    }
                
              
                    
                  

                }


               

            }
        }
        else
        {
            //var a = Instantiate(SpawnEffect.Instance.getEffectName("Status"), null);
            //a.GetComponent<Status>().SetText("NOT CONNECT WITH INTERNET");

        }
    }

    public IEnumerator Process_Loading(int index, GameObject game, float wait_time, bool isComplete, bool isPlayer)
    {
          Debug.Log("INDEX : "+index);
        Process_Player process;
        if (isPlayer)
        {
            process = DataMananger.Instance.Set_Infor_Player();
            
        }
        else
        {
            process = DataMananger.Instance.Set_Random_Infor();
               Debug.Log(process.name);
        }

            list_Process.Add(process);
            // yield return new WaitForSeconds(Time.deltaTime * index*10);
            yield return new WaitForSeconds(wait_time);
        game.GetComponent<LoadInfor>().SetImage(process.sprite);
        if (isComplete)
        {
            DataMananger.Instance.Push_Data(list_Process);
            DataMananger.Instance.CountPlayer = numberPlayer-1;
             yield return new WaitForSeconds(4);
            GameMangaer.Instance.Open_Screen(Screen_Type.Screen_Play);

            Debug.Log("Start_Game");

        }

    }
    
  
  
}

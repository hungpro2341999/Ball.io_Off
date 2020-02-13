using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Mananger : MonoBehaviour
{
    public static int Stuff_Choice=-1;
    public static Shop_Mananger Instance = null;
    public GameObject Skill;
    public Transform parent;
    public static string Cost ="";
    public Text Text_Cost;
    public  List<GameObject> listSkill;
    public Transform Parent_Review;
    public static Transform Review;
    public Image ActiveCoin;
    float lastValue = 0;
    public Transform Shop;

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
    }
    public void Active_Coin(bool active)
    {
        ActiveCoin.enabled = active;
    }
    // Start is called before the first frame update
    void Start()
    {
        Active_Coin(false);
        Shop_Mananger.Review = Parent_Review;
       // Load_Shop();
    }

    // Update is called once per frame
    void Update()
    {
        string s = Screen.currentResolution.ToString();
        Debug.Log(s);
        //-1230
        if (s.StartsWith("1920 x 1080"))
        {
            Shop.localScale = new Vector3(0.9f, 0.9f, 0.9f);

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
  
        }

        Text_Cost.text = Shop_Mananger.Cost;
        int a = 0;
        if (int.TryParse(Text_Cost.text, out a))
        {
            Active_Coin(true);
        }
        else
        {
            Active_Coin(false);
        }
    }
    public void Load_Shop()
    {
        int count = DataMananger.Instance.Data_Skills.ListModel.Count;
        Debug.Log("LOAD : " + count);
        for(int i = 0; i < count; i++)
        {
           var a = Instantiate(Skill, parent);
          
            a.GetComponent<InforSkill>().infor  = DataMananger.Instance.Data_Skills.List_infor_Skill[i];
            a.GetComponent<InforSkill>().Load_Infor(i);
            listSkill.Add(a);
        }
    }
    public void AddSkin(GameObject Skin)
    {
        if (!listSkill.Contains(Skin))
        {
            listSkill.Add(Skin);
        }
       
    }
    public void RemoveSkin(GameObject Skin)
    {
        listSkill.Remove(Skin);
    }
    public void SetCode(string cost)
    {
       
      
        Shop_Mananger.Cost = cost;

    }
    public static  void Choice(int id)
    {
        Debug.Log("Select Skin : " + id);
        Stuff_Choice = id;
      for(int i = 0; i < Shop_Mananger.Instance.listSkill.Count; i++)
        {
            if (Shop_Mananger.Instance.listSkill[i].GetComponent<InforSkill>().infor.id == id)
            {

             //   Debug.Log("CHILD :: " +Shop_Mananger.Review.childCount);
                if (Shop_Mananger.Review.childCount >= 1)
                {
                    Shop_Mananger.Review.GetChild(0).GetComponent<Destroy_Review>().Destroy();
                }

                Shop_Mananger.Instance.listSkill[i].GetComponent<InforSkill>().Choice();
                var a =    Instantiate(DataMananger.Instance.Data_Skills.ListModel[id],Shop_Mananger.Review);

                a.transform.localPosition = Vector3.zero;
                a.transform.localScale = Vector3.one;
                a.AddComponent<Destroy_Review>();
            }
            else
            {
              
                Shop_Mananger.Instance.listSkill[i].GetComponent<InforSkill>().Un_Choice();
            }

        }
    }
    public void Buy()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {


            if (Text_Cost.text != "USE")
            {


                if (Stuff_Choice != -1)
                {
                    for (int i = 0; i < listSkill.Count; i++)
                    {
                        InforSkill infor = Shop_Mananger.Instance.listSkill[i].GetComponent<InforSkill>();
                        if (Stuff_Choice == infor.infor.id)
                        {
                            if (!infor.infor.isBuy)
                            {
                                if (infor.infor.Cost <= DataMananger.Instance.Get_Coin_Current())
                                {
                                    Active_Coin(false);
                                    DataMananger.Instance.Earn_Coin(infor.infor.Cost);
                                    infor.infor.isBuy = true;
                                    SetCode("USE");
                                    Load_Infor();

                                    var a = Instantiate(SpawnEffect.Instance.getEffectName("Status"), null);
                                    a.GetComponent<Status>().SetText("BUYED SKIN COMPLETED !!!");

                                }
                                else
                                {
                                    var a = Instantiate(SpawnEffect.Instance.getEffectName("Status"), null);
                                    a.GetComponent<Status>().SetText("NOT ENOUGHT MONEY !!!");
                                }

                            }
                        }

                    }
                }

                else
                {
                    var a = Instantiate(SpawnEffect.Instance.getEffectName("Status"), null);
                    a.GetComponent<Status>().SetText("CHOICE SOMETHING MAN !!!");
                }
            }
            else if (Text_Cost.text == "USE")
            {


                DataMananger.Instance.Set_Id_Skin_Use(Stuff_Choice);
                Review_Skin.Instance.SetUpSkin();
                var a = Instantiate(SpawnEffect.Instance.getEffectName("Status"), null);
                a.GetComponent<Status>().SetText("Change Skin Completed !!!");
                Debug.Log("USE" + "   " + DataMananger.Instance.Get_Id_Skin());



            }
        }
        else
        {
            var a = Instantiate(SpawnEffect.Instance.getEffectName("Status"), null);
            a.GetComponent<Status>().SetText("NOT CONNECT INTERNET !!!");
        }
    }
    public void Load_Infor()
    {
      
        List<Infor_Skill> List_new = new List<Infor_Skill>();
        List<Infor_Skill> lists_Curr = JsonUtility.FromJson<List_Infor_Skill>(PlayerPrefs.GetString("Key_Shop")).lists;
        Debug.Log("LENGHT_COUNT : " +lists_Curr.Count);
      
        for (int i=0;i< DataMananger.Instance.Data_Skills.Images.Count; i++)
        {
            if (Shop_Mananger.Instance.HasIndexSkin(i))
            {
                Debug.Log("index" + i);
                //Infor_Skill infor = new Infor_Skill(i, Shop_Mananger.Instance.listSkill[i].GetComponent<InforSkill>().infor.isBuy,
                //Shop_Mananger.Instance.listSkill[i].GetComponent<InforSkill>().infor.isUse, DataMananger.Instance.Data_Skills.Cost[i]);
                Infor_Skill infor = Infor_Skin(i);
                List_new.Add(infor);
            }
            else
            {
                List_new.Add(lists_Curr[i]);
            }
        }
        
        DataMananger.Instance.Save_Shop(List_new);
        DataMananger.Instance.Render();
       
        
    }
    public Infor_Skill Infor_Skin(int id)
    {
        for(int i = 0; i < listSkill.Count; i++)
        {
            if (listSkill[i].GetComponent<InforSkill>().infor.id == id)
            {
                return new Infor_Skill(listSkill[i].GetComponent<InforSkill>().infor.id, listSkill[i].GetComponent<InforSkill>().infor.isBuy,
                    listSkill[i].GetComponent<InforSkill>().infor.isUse, DataMananger.Instance.Data_Skills.Cost[i]);
            }
        }
        return null;
    }
    public bool HasIndexSkin(int index)
    {
        bool isContainer = false;
        for(int i = 0; i < listSkill.Count; i++)
        {
            if (listSkill[i].GetComponent<InforSkill>().infor.id == index)
            {
                isContainer = true;
            }
            
        }
        return isContainer;
    }


  






}

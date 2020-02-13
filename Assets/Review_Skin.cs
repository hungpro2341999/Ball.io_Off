using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Review_Skin : MonoBehaviour
{
   
    public static Review_Skin Instance = null;
    public Transform Parent_Skin;
    public int id_Skin;
    public Vector3 pos_init;
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
    // Start is called before the first frame update
    void Start()
    {
       
        GamePlayerCtrl.Instance.Event_Reset_Game += UnActiveSkin;
        GamePlayerCtrl.Instance.Event_Over_Game += ActiveSkin;
       SetUpSkin();
    }
   
    // Update is called once per frame
    void Update()
    {
        if (DataMananger.MapSelec != 3)
        {
            GetComponent<FloatingObject>().enabled = false;
        }
        else
        {
            GetComponent<FloatingObject>().enabled = true;
        }
    }
    public void SetUpSkin()
    {
        Parent_Skin.GetChild(0).gameObject.AddComponent<Destroy_Review>().Destroy();
        int id = DataMananger.Instance.Get_Id_Skin();
        id_Skin = id;
        var a = Instantiate(DataMananger.Instance.Data_Skills.ListModel[id], Parent_Skin);
        a.transform.localScale = Vector3.one;
        a.transform.localPosition = Vector3.zero;
    }
    public void ActiveSkin()
    {
        gameObject.SetActive(true);
    }
    public void UnActiveSkin()
    {
        gameObject.SetActive(false);
    }
    public void Set_Active(bool active)
    {
        gameObject.SetActive(active);
    }
    private void OnDisable()
    {
        transform.position = pos_init;
        transform.eulerAngles = Vector3.zero;
    }
    private void OnEnable()
    {

        transform.position = pos_init;
        transform.eulerAngles = Vector3.zero;



    }
}

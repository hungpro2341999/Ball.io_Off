using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public bool IsOpenDropBox = true;
    public bool isMute = false;
    public bool isVariable = false;
    public Transform OnSound;
    public Transform OffSound;
    public Transform OnVariable;
    public Transform OffVariable;
    public Animator Anim_DropBox;
    private void OnEnable()
    {
        Anim_DropBox.SetBool("Open",false);
        IsOpenDropBox = false;
    }
    // Start is called before the first frame update
    void Start()
    {
      
        if (DataMananger.Instance.Is_Mute() == 1)
        {
            OnSound.gameObject.SetActive(true);
            OffSound.gameObject.SetActive(false);
        }
        else
        {
            OnSound.gameObject.SetActive(false);
            OffSound.gameObject.SetActive(true);
        }

        if (DataMananger.Instance.Is_Variable() == 1)
        {
            OnVariable.gameObject.SetActive(true);
            OffVariable.gameObject.SetActive(false);
        }
        else
        {
            OnVariable.gameObject.SetActive(false);
            OffVariable.gameObject.SetActive(true);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open_DropBox()
    {
        Debug.Log("OPENDROPBOX");
        IsOpenDropBox = !IsOpenDropBox;
        Anim_DropBox.SetBool("Open",IsOpenDropBox);
    }
    public void Set_Mute(bool Mute)
    {
        DataMananger.Instance.Save_On_Off_Sound(!Mute);
        if (Mute)
        {
            OnSound.gameObject.SetActive(false);
            OffSound.gameObject.SetActive(true);
        }
        else
        {
            OnSound.gameObject.SetActive(true);
            OffSound.gameObject.SetActive(false);
        }
    }
    public void Set_Variable(bool Var)
    {
        DataMananger.Instance.Save_On_Off_Variable(!Var);
        if (Var)
        {
            OnVariable.gameObject.SetActive(false);
            OffVariable.gameObject.SetActive(true);
        }
        else
        {
            OnVariable.gameObject.SetActive(true);
            OffVariable.gameObject.SetActive(false);
        }
    }
}

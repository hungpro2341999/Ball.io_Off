using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dot_Ctrl : MonoBehaviour

{
    public List<GameObject> DotSelect;
    public List<GameObject> DotUnSelect;
    // Start is called before the first frame update
    void Start()
    {
        Select_At_Index(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Select_At_Index(int index)
    {
        for(int i = 0; i < 3; i++)
        {
            if (index == i)
            {
                DotSelect[i].gameObject.SetActive(true);
                DotUnSelect[i].gameObject.SetActive(false);
            }
            else
            {
                DotSelect[i].gameObject.SetActive(false);
                DotUnSelect[i].gameObject.SetActive(true);
            }
        }
    }
}

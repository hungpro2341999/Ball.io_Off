using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderResult : MonoBehaviour
{
    public Image Defeat;
    public Image Victory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Result()
    {
        if (GamePlayerCtrl.isPlayerWin)
        {
            Defeat.enabled = false;
            Victory.enabled = true;
        }
        else
        {
            Defeat.enabled = true;
            Victory.enabled = false;

        }
    }
    private void OnEnable()
    {
        Result();
    }
    private void OnDisable()
    {
        GamePlayerCtrl.isPlayerWin = false;
    }
}

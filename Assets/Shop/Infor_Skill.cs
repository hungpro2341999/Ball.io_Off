using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class Infor_Skill 
{
    public int id;
    public bool isBuy = false;
    public bool isUse = false;
    public int Cost;
public Infor_Skill(int id,bool isBuy,bool isUse,int Cost)
    {
        this.id = id;
        this.isBuy = isBuy;
        this.isUse = isUse;
        this.Cost = Cost;
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Totem : MonoBehaviour
{
    public int CurrentX{ set; get; }
    public int CurrentY{ set; get; }
    public bool isCross;
    //Totem element type
    public Element TotemElementType;

    //Totem Stats
    public string totemName;
    public int totemMaxHP;
    public int totemCurrentHP;
    public int totemDamage;
    public int totemCurrentDamage;
    public int totemDefence;
    public int totemCritDamage;

    public void SetPosition(int x, int y)
    {

        CurrentX = x;
        CurrentY = y;

    }
    void OnTotemSelect()
    {

        
    }
   

    void Start()
    {




    }
}


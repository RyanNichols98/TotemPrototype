using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Totem : MonoBehaviour
{
   
   
    //Totem element type
    public Element TotemElementType;

    public Transform TotemTarget { get; set; }

    //Totem Stats
    public string totemName;
    public int totemMaxHP;
    public int totemCurrentHP;
    public int totemDamage;
    public int totemCurrentDamage;
    public int totemDefence;
    public int totemCritDamage;

    public bool isCross;
    void OnTotemSelect()
    {
       

      GameObject.Find("Game Manager").SendMessage("TotemClicked", gameObject);
            


    }
   

    void Start()
    {




    }
}


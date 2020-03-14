using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum WhatisTotem { X, O }
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
    public int totemCurrentDefence;
    public int totemCritDamage;
    public bool isDefending = false;
    public bool isTotemOcc = false;
    public ClickableSquare totemsquarenumber;
    public bool hasAttack;
   

    public WhatisTotem totemIs; 
   
   void Update()
    {


        SetTotemHealth();

    }
   

    void SetTotemHealth()
    {    

        if (totemCurrentHP <= 0)
        {
            DestoryTotem();
        }

        else
            return;

    }
   public void TakeDamage(Totem totem)
    {
        totemCurrentHP += totemCurrentDefence;
        totemCurrentHP -= totem.totemDamage;
        isDefending = false;
        Debug.Log(totem.totemDamage);
        Debug.Log(totemName);

        if (totemCurrentHP <= 0)
        {
            DestoryTotem();
        }

        else
            return;

    }
   public  void TakeCritDamage()
    {
        totemCurrentDamage = totemCritDamage + totemDamage;
        totemCurrentHP -= totemCurrentDamage;
        isDefending = false;

        if (totemCurrentHP <= 0)
        {
            DestoryTotem();
        }

        else
            return;
    }
    

   

   public void TotemDefend()
    {
        if (isDefending == false)
        {
            totemCurrentDefence += totemDefence;
            isDefending = true;
        }
        else if (isDefending == true)
            return;


    }

  
    public void DestoryTotem()
    {
        totemsquarenumber.GetComponent<ClickableSquare>().EnableSquare();
        Destroy(gameObject);
    }
    
  
}


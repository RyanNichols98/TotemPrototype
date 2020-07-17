using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum WhatisTotem { X, O }
[System.Serializable]
public class Totem : MonoBehaviour
{


    //Totem element type
    public Element TotemElementType;

    //Materials for totem
    public Material Player1;
    public Material Player2;
    public Material TotemMat;

    //Totem Stats
    public string totemName;
    public int totemMaxHP;
    public int totemCurrentHP;
    public int totemDamage;
    public int totemCurrentDamage;
    public int totemMinHealth;
    public int totemDefence;
    public int totemCurrentDefence;
    public int totemCritDamage;
    public bool isDefending = false;
    public bool isTotemOcc = false;
    public bool hasAttack;
    public bool IsDead;
    public string Weakness;
    public string Strength;
    // Tile that Totem is on
    public ClickableSquare totemsquarenumber = null;
    public int TotemTileNumber;
    public ClickableSquare[] Tiles;


    // GameState

    GameState Battlestate;
    public WhatisTotem totemIs; 
   
   void Update()
    {


        SetTotemHealth();

    }

    public void Awake()
    {
        FindObjectOfType<SoundManager>().Play("TotemPlacedAudio");
    }
    public void SetMat()
    {

        switch (totemIs)
        {
            case WhatisTotem.X:
                TotemMat = Player2;
                gameObject.GetComponentInChildren<Renderer>().material = TotemMat;
                break;
            case WhatisTotem.O:
                TotemMat = Player1;
                gameObject.GetComponentInChildren<Renderer>().material = TotemMat;
                break;
            
        }




    }
    public void DestoryTotem()
    {
        FindObjectOfType<GameManager>().EnableTile(totemsquarenumber);
        IsDead = true;
        Destroy(gameObject);
        Debug.Log(totemName + " is Destroyed");
        FindObjectOfType<SoundManager>().Play("TotemDeathAudio");
    }
    public void SetTotemHealth()
    {    

        if (totemCurrentHP <= totemMinHealth)
        {
            totemCurrentHP = totemMinHealth;
            DestoryTotem();
            return;
        }

        else
            return;

    }
   public void TakeDamage(Totem totemA, Totem totemB)
    {
        if (totemA.hasAttack == false)
        {


            totemA.totemCurrentDamage = totemA.totemDamage;
            if (totemB.isDefending == true)
            {
              
                totemB.totemCurrentDefence -= totemA.totemDamage;
                totemB.totemCurrentDefence = 0;
                totemB.isDefending = false;
            }
            else if (totemB.isDefending == false)
            {

                totemB.totemCurrentHP -= totemA.totemDamage;

            }

            Debug.Log(totemName);
            SetTotemHealth();

            totemA.HasTotemAttacked(totemA);
        }

        else
        {

            Debug.Log(totemName + " has already attacked!");

        }

    }
   public  void TakeCritDamage(Totem totemA, Totem totemB)
    {
        if (totemA.hasAttack == false)
        {


            totemA.totemCurrentDamage = totemA.totemDamage;
            if (totemB.isDefending == true)
            {
                totemB.totemCurrentDefence -= totemA.totemDamage;
                totemB.totemCurrentDefence = 0;
                totemB.isDefending = false;
            }
            else if (totemB.isDefending == false)
            {

                totemB.totemCurrentHP -= totemA.totemCurrentDamage = totemA.totemCritDamage + totemA.totemDamage;
                totemB.totemCurrentDefence = 0;
                totemB.isDefending = false;


            }

            Debug.Log(totemName);
            SetTotemHealth();
            totemA.HasTotemAttacked(totemA);

        }

        else
        {

            Debug.Log(totemName + " has already attacked!");

        }

       
        


        SetTotemHealth();
       
   }
  
    public void HasTotemAttacked(Totem totemA)
    {
        if (totemA.hasAttack == false)
        {
            totemA.hasAttack = true;
        }

        else
            return;
    }

   




    
    public void TotemDefend(Totem totemA)
    {
        if (totemA.isDefending == false)
        {
            totemA.totemCurrentDefence += totemA.totemDefence;
            totemA.isDefending = true;
            FindObjectOfType<SoundManager>().Play("TotemDefAudio");
        }
        else if (totemA.isDefending == true)
            return;


    }

    

  
 
    
  
}


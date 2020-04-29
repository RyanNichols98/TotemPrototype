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
   public void TakeDamage()
    {
        totemCurrentDamage = totemDamage;
        if (isDefending == true)
        {
            totemCurrentHP += totemCurrentDefence;
            totemCurrentHP -= totemDamage;
            totemCurrentDefence = 0;
            isDefending = false;
        }
        else if (isDefending == false)
        {

            totemCurrentHP -= totemDamage;

        }
       
        Debug.Log(totemName);
        SetTotemHealth();
        

    }
   public  void TakeCritDamage()
    {
        
            
            totemCurrentHP -= totemCurrentDamage = totemCritDamage + totemDamage;
        totemCurrentDefence = 0;
        isDefending = false;
        
       
        


        SetTotemHealth();
       
   }
  
    public void AttackTotem()
    {
            hasAttack = true;

        switch (Battlestate)
        {
            
            case GameState.PLAYER_1_TURN:
                if (totemIs == WhatisTotem.O)
                {

                    hasAttack = true;
                }
                else if(totemIs == WhatisTotem.X)
                {

                    hasAttack = false;
                }
                break;
            case GameState.PLAYER_2_TURN:
                if (totemIs == WhatisTotem.X)
                {

                    hasAttack = true;
                }
                else if (totemIs == WhatisTotem.O)
                {

                    hasAttack = false;
                }
                break;
        
        }
       
    }

   




    
    public void TotemDefend()
    {
        if (isDefending == false)
        {
            totemCurrentDefence += totemDefence;
            totemCurrentHP += totemCurrentDefence;
            isDefending = true;
            FindObjectOfType<SoundManager>().Play("TotemDefAudio");
        }
        else if (isDefending == true)
            return;


    }

    

  
 
    
  
}


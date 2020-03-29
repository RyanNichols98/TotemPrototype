using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum WhatisTotem { X, O }
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

    // Tile that Totem is on
    public ClickableSquare totemsquarenumber;  
    public GameObject[] Tiles;

    // GameState
    
    GameState Battlestate;
    public WhatisTotem totemIs; 
   
   void Update()
    {


        SetTotemHealth();

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
       
        IsDead = true;
        if  (Tiles == null)
            Tiles = GameObject.FindGameObjectsWithTag("Tile"); 

        foreach (GameObject Tile in Tiles)
        {
            if (Tile.GetComponent<ClickableSquare>().SquareNumber == totemsquarenumber.SquareNumber)
            {
                totemsquarenumber.IsPlaneOcc = false;
                Tile.GetComponent<ClickableSquare>().EnableSquare();
                totemsquarenumber.GetComponent<ClickableSquare>().EnableSquare();
            }
            else
                Debug.Log("Fuck");
        }
        
        Destroy(gameObject);
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
        if (isDefending == true)
        {
            totemCurrentHP += totemCurrentDefence;
            totemCurrentHP -= totemCurrentDamage = totemCritDamage + totemDamage;
            totemCurrentDefence = 0;
            isDefending = false;
        }
        else if (isDefending == false)
        {

            totemCurrentHP -= totemCurrentDamage = totemCritDamage + totemDamage;

        }
        


        SetTotemHealth();
       
   }
  
    public void AttackTotem()
    {
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
            isDefending = true;
           
        }
        else if (isDefending == true)
            return;


    }

    

  
 
    
  
}


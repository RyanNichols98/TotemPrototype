using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum WhatisTotem { X, O }
public class Totem : MonoBehaviour
{
    //Totem element type
    public Element TotemElementType;
    public GameObject FloatingText;
    public Transform TotemTarget { get; set; }

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
    public ClickableSquare totemsquarenumber;
    public bool hasAttack;
    public bool IsDead;
    public GameObject[] Tiles;
    GameState Battlestate;
    

    public WhatisTotem totemIs; 
   
   void Update()
    {


        SetTotemHealth();

    }

    public void DestoryTotem()
    {
        IsDead = true;

        totemsquarenumber.IsPlaneOcc = false;
        if  (Tiles == null)
            Tiles = GameObject.FindGameObjectsWithTag("Tile"); 

        foreach (GameObject Tile in Tiles)
        {
            if (Tile == totemsquarenumber)
            {
                totemsquarenumber.IsPlaneOcc = false;
                Tile.GetComponent<ClickableSquare>().EnableSquare();
                totemsquarenumber.GetComponent<ClickableSquare>().EnableSquare();
            }
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
   public void TakeDamage(Totem totem)
    {
        totemCurrentDamage = totemDamage;
        if (isDefending == true)
        {
            totemCurrentHP += totemCurrentDefence;
            totemCurrentHP -= totem.totemDamage;
            totemCurrentDefence = 0;
            isDefending = false;
        }
        else if (isDefending == false)
        {

            totemCurrentHP -= totem.totemDamage;

        }
       
        ShowFloatingText();
        Debug.Log(totem.totemDamage);
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
        ShowFloatingText();



        SetTotemHealth();
       
   }
    void ShowFloatingText()
    {

        Instantiate(FloatingText, transform.position, transform.rotation * Quaternion.Euler(90f, 0f, 0f));
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


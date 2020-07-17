using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public BattleHUD HUD;
    public Text totemName;
    public Text HealthText;
    public Text DmgText;
    public Text DefText;


    public GameObject EarthPanel;
    public GameObject FirePanel;
    public GameObject WaterPanel;
    public GameObject AirPanel;
    public GameObject TotemPanel;
  

    public Text CombatText;

    public Button AtkButton;
    public Button DefButton;

    public bool IsP1;

    public GameState GameState;
    public GameManager MainManager;

    public void ResetHUD(Totem totem)
    {
        HUD.gameObject.SetActive(false);
        //DmgText.text = null;
        //DefText.text = null;

        


    }

    public void SetHUD(Totem totem)
    {
        Debug.Log("HUD" + totem + " Active");
        HUD.gameObject.SetActive(true);
        totemName.text = totem.totemName;
        SetHP(totem.totemCurrentHP);
        DmgText.text = totem.totemDamage.ToString();
        DefText.text = totem.totemCurrentDefence.ToString();
        ActionHUDReset(totem);


        switch (totem.TotemElementType)
        {
            case Element.Fire:
                EarthPanel.active = false;
                FirePanel.active = true;
                WaterPanel.active = false;
                AirPanel.active = false;
                TotemPanel.active = false;
                break;
            case Element.Water:
                EarthPanel.active = false;
                FirePanel.active = false;
                WaterPanel.active = true;
                AirPanel.active = false;
                TotemPanel.active = false;
                break;
            case Element.Earth:
                EarthPanel.active = true;
                FirePanel.active = false;
                WaterPanel.active = false;
                AirPanel.active = false;
                TotemPanel.active = false;
                break;
            case Element.Air:
                EarthPanel.active = false;
                FirePanel.active = false;
                WaterPanel.active = false;
                AirPanel.active = true;
                TotemPanel.active = false;
                break;
            default:
                EarthPanel.active = false;
                FirePanel.active = false;
                WaterPanel.active = false;
                AirPanel.active = false;
                TotemPanel.active = true;
                break;

        }

        
    }
   

    public void ActionHUDReset(Totem totem)
    {
        
        GameState = MainManager.gameState;
        if (totem.totemIs == WhatisTotem.O)
        {
            switch (GameState)
            {
                case GameState.PLAYER_1_TURN:
                    AtkButton.enabled = true;
                    DefButton.enabled = true;
                    break;
                case GameState.PLAYER_2_TURN:
                    AtkButton.enabled = false;
                    DefButton.enabled = false;
                    break;
            }
        }
        if (totem.totemIs == WhatisTotem.X)
        {
            switch (GameState)
            {
                case GameState.PLAYER_1_TURN:
                    AtkButton.enabled = false;
                    DefButton.enabled = false;
                    break;
                case GameState.PLAYER_2_TURN:
                    AtkButton.enabled = true;
                    DefButton.enabled = true;
                    break;
            }
        }


    }


    public void SetHP (int hp)
    {


        HealthText.text = hp.ToString();


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}

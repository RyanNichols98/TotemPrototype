using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public BattleHUD HUD;
    public Text totemName;
    public Slider hpSlider;
    public Text DmgText;
    public Text DefText;
    public Text Wkn;
    public Text Str;

    public Image EarthPanel;
    public Image FirePanel;
    public Image WaterPanel;
    public Image AirPanel;
    public Image TotemPanel;
  

    public Text CombatText;

    public Button AtkButton;
    public Button DefButton;

    

    GameState GameState;


    public void ResetHUD()
    {
        HUD.gameObject.SetActive(false);
        DmgText.text = null;
        DefText.text = null;



    }

    public void SetHUD(Totem totem)
    {
        Debug.Log("HUD" + totem + " Active");
        HUD.gameObject.SetActive(true);
        totemName.text = totem.totemName;
        SetHP(totem.totemCurrentHP);
        hpSlider.maxValue = totem.totemMaxHP;
        SetHP(totem.totemCurrentHP);
        hpSlider.value = totem.totemCurrentHP;
        DmgText.text = totem.totemDamage.ToString();
        DefText.text = totem.totemCurrentDefence.ToString();
        Str.text = totem.Strength;
        Wkn.text = totem.Weakness;
      
        switch (totem.TotemElementType)
        {
            case Element.Fire:
                EarthPanel.enabled = false;
                FirePanel.enabled = true;
                WaterPanel.enabled = false;
                AirPanel.enabled = false;
                TotemPanel.enabled = false;
                break;
            case Element.Water:
                EarthPanel.enabled = false;
                FirePanel.enabled = false;
                WaterPanel.enabled = true;
                AirPanel.enabled = false;
                TotemPanel.enabled = false;
                break;
            case Element.Earth:
                EarthPanel.enabled = true;
                FirePanel.enabled = false;
                WaterPanel.enabled = false;
                AirPanel.enabled = false;
                TotemPanel.enabled = false;
                break;
            case Element.Air:
                EarthPanel.enabled = false;
                FirePanel.enabled = false;
                WaterPanel.enabled = false;
                AirPanel.enabled = true;
                TotemPanel.enabled = false;
                break;
            default:
                EarthPanel.enabled = false;
                FirePanel.enabled = false;
                WaterPanel.enabled = false;
                AirPanel.enabled = false;
                TotemPanel.enabled = true;
                break;

        }

        switch (GameState)
        {
            
            case GameState.PLAYER_1_TURN:
                switch (totem.totemIs)
                {
                    case WhatisTotem.X:
                        AtkButton.enabled = false;
                        DefButton.enabled = false;
                        break;
                    case WhatisTotem.O:
                        AtkButton.enabled = true;
                        DefButton.enabled = true;
                        break;
                    default:
                        break;
                }
                break;
            case GameState.PLAYER_2_TURN:
                switch (totem.totemIs)
                {
                    case WhatisTotem.X:
                        AtkButton.enabled = true;
                        DefButton.enabled = true;
                        break;
                    case WhatisTotem.O:
                        AtkButton.enabled = false;
                        DefButton.enabled = false;
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }

    }

  


    

    
    public void SetHP (int hp)
    {


        hpSlider.value = hp;


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

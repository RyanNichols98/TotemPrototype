using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour
{

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
    public Image P1_Icon;
    public Image P2_Icon;
    public Image P1_TotIcon;
    public Image P2_TotIcon;

    public Text CombatText;

    public Button AtkButton;
    public Button DefButton;



    GameState GameState;


    public void ResetHUD()
    {

        totemName.text = null;
        hpSlider.maxValue = 5;
        hpSlider.value = 5;
        DmgText.text = null;
        DefText.text = null;
        Str.text = null;
        Wkn.text = null;
        //AtkButton.enabled = false;
        //DefButton.enabled = true;
        EarthPanel.enabled = false;
        FirePanel.enabled = false;
        WaterPanel.enabled = false;
        AirPanel.enabled = false;
        TotemPanel.enabled = true;



    }

    public void SetHUD(Totem totem)
    {
        totemName.text = totem.totemName;
        hpSlider.maxValue = totem.totemMaxHP;
        hpSlider.value = totem.totemCurrentHP;
        DmgText.text = totem.totemDamage.ToString();
        DefText.text = totem.totemCurrentDefence.ToString();
        Str.text = totem.Strength;
        Wkn.text = totem.Weakness;
        AtkButton.enabled = false;
        DefButton.enabled = true;
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

        switch (totem.totemIs)
        {
            case WhatisTotem.X:
                P2_TotIcon.enabled = true;
                P1_TotIcon.enabled = false;
                break;
            case WhatisTotem.O:
                P1_TotIcon.enabled = true;
                P2_TotIcon.enabled = false;
                break;
            default:
                break;
        }

    }

    
   


    public void SetHP(int hp)
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{

    public Text totemName;
    public Slider hpSlider;
    public Text DmgText;
    public Text DefText;

    public Image EarthPanel;
    public Image FirePanel;
    public Image WaterPanel;
    public Image AirPanel;
    public Image TotemPanel;
    public Image P1_Icon;
    public Image P2_Icon;

    public Text CombatText;

   

    GameState GameState;




    public void SetHUD(Totem totem)
    {
        totemName.text = totem.totemName;
        hpSlider.maxValue = totem.totemMaxHP;
        hpSlider.value = totem.totemCurrentHP;
        DmgText.text = totem.totemDamage.ToString();
        DefText.text = totem.totemDefence.ToString();


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
       

    }
    public void SetCombatText(GameState gamestate)
    {
        GameState = gamestate; 
        switch (GameState)
        {
            case GameState.START:
                break;
            case GameState.PLAYER_1_TURN:
                CombatText.text = "Player One Turn";
                P1_Icon.enabled = true;
                P2_Icon.enabled = false;
                break;
            case GameState.PLAYER_2_TURN:
                CombatText.text = "Player Two Turn";
                P1_Icon.enabled = false;
                P2_Icon.enabled = true;
                break;
            case GameState.END:
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

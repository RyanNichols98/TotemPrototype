using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{

    public Text totemName;
    public Slider hpSlider;

    public void SetHUD(Totem totem)
    {
        totemName.text = totem.totemName;
        hpSlider.maxValue = totem.totemMaxHP;
        hpSlider.value = totem.totemCurrentHP;



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

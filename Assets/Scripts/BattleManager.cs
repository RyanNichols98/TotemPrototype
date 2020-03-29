﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;



public class BattleManager : MonoBehaviour
{
    public BattleHUD battleHUD;

    public GameObject FloatingDMGText;
    public GameObject FloatingDEFText;

    public float rayLength;
    public LayerMask layermask;
    public Totem[,] Totems { set; get;}
    public Totem ActiveTotem;
    public Totem EnemyTotem;
    public GameState BattleGameState;
    public GameManager MainGameManager;
    Element Acttotemelementtype;
    Element Enetotemelementtype;
    public bool hasAttacked = false;
    Renderer r;
    Material m;
    Material hm;


    public void setGameState()
    {

        BattleGameState = MainGameManager.gameState;
        hasAttacked = false;

       


    }

    void Update()
    {

     
        
        Selection();
        


    }
    
    public void Selection()

    {   
    

            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
           
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            //bool didHit = Physics.Raycast(toMouse, out rhInfo, 500.0f);
            if (Physics.Raycast(toMouse, out rhInfo, rayLength, layermask))
            {

                var Selectedtotem = rhInfo.collider.gameObject.GetComponent<Totem>();
                Debug.Log(rhInfo.collider.name);
                
                switch (BattleGameState)
                {

                    case GameState.PLAYER_1_TURN:
                        switch (Selectedtotem.totemIs)
                        {
                            case WhatisTotem.O:
                                ActiveTotem = Selectedtotem;
                                battleHUD.SetHUD(ActiveTotem);
                                break;
                            case WhatisTotem.X:
                                EnemyTotem = Selectedtotem;
                                battleHUD.SetEnemyHUD(EnemyTotem,ActiveTotem);
                                break;
                          
                               
                            default:
                                break;
                        }
                      

                        break;
                    case GameState.PLAYER_2_TURN:
                        switch (Selectedtotem.totemIs)
                        {
                            case WhatisTotem.X:
                                ActiveTotem = Selectedtotem;
                                battleHUD.SetHUD(ActiveTotem);
                                break;
                            case WhatisTotem.O:
                                EnemyTotem = Selectedtotem;
                                battleHUD.SetEnemyHUD(EnemyTotem, ActiveTotem);
                                break;
                            default:
                                break;
                        }
                   


                        break;

                }

               
            }

            else
            {
                
                ClearSelection();
                Debug.Log("Nothing");
            }

        }

        




    }

    void ShowDMGFloatingText(Vector3 postion)
    {
        postion.y = 30f;
        var go = Instantiate(FloatingDMGText, postion, Quaternion.Euler(new Vector3(45, -90, 0)));
        go.GetComponent<TextMesh>().text = "- " + EnemyTotem.totemCurrentDamage.ToString() + " Hp";
    }

    void ShowDEFFloatingText(Vector3 postion)
    {
        postion.y = 30f;
        var go = Instantiate(FloatingDEFText, postion, Quaternion.Euler(new Vector3(45, -90, 0)));
        go.GetComponent<TextMesh>().text = "+ " + ActiveTotem.totemDefence.ToString() + " Def";
    }

    public void ClearSelection()
    {
       
        EnemyTotem = null;
        ActiveTotem = null;
    }
    
    public void OnAttackButton()
    {
        
    
        if (ActiveTotem.hasAttack == false)
        {
            battleHUD.SetEnemyHUD(EnemyTotem, ActiveTotem);
            ActiveTotem.AttackTotem();
            Acttotemelementtype = ActiveTotem.TotemElementType;
            Enetotemelementtype = EnemyTotem.TotemElementType;
            switch (Acttotemelementtype)
            {
                case Element.Fire:
                    if(Enetotemelementtype == Element.Earth)
                    {

                        EnemyTotem.TakeCritDamage();
                        battleHUD.SetEnemyHUD(EnemyTotem, ActiveTotem);
                    }
                    else
                    {
                        EnemyTotem.TakeDamage();
                    }
                    break;
                case Element.Water:
                    if (Enetotemelementtype == Element.Fire)
                    {

                        EnemyTotem.TakeCritDamage();
                        battleHUD.SetEnemyHUD(EnemyTotem, ActiveTotem);
                    }
                    else
                    {
                        EnemyTotem.TakeDamage();
                    }
                    break;
                case Element.Earth:
                    if (Enetotemelementtype == Element.Water)
                    {

                        EnemyTotem.TakeCritDamage();
                        battleHUD.SetEnemyHUD(EnemyTotem, ActiveTotem);
                    }
                    else
                    {
                        EnemyTotem.TakeDamage();
                    }
                    break;
                case Element.Air:
                    if (Enetotemelementtype == Element.Air)
                    {

                        EnemyTotem.TakeCritDamage();
                        battleHUD.SetEnemyHUD(EnemyTotem, ActiveTotem);
                    }
                    else
                    {
                        EnemyTotem.TakeDamage();
                        
                    }
                    break;
                default:
                    
                    break;

            }
                ShowDMGFloatingText(EnemyTotem.transform.position);
            if (EnemyTotem.IsDead)
            {
                battleHUD.SetHUD(ActiveTotem);
               
            }
            
            else
            battleHUD.SetEnemyHUD(EnemyTotem, ActiveTotem);
            hasAttacked = true;
            return;
        }
       

        else
        {

            return;
        }
       
    }

    public void OnDefendButton()
    {

        if (ActiveTotem.isDefending == false)
        {
            ActiveTotem.TotemDefend();
            battleHUD.SetHUD(ActiveTotem);
            ShowDEFFloatingText(ActiveTotem.transform.position);
            if (ActiveTotem.totemCurrentHP <= 0)
                Destroy(ActiveTotem.gameObject);

            else
                battleHUD.SetHUD(ActiveTotem);
            return;

           

        }
        else
            return;
       
    }

   
}



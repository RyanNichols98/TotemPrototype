using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;



public class BattleManager : MonoBehaviour
{
    //General Battle System Variables
    public BattleHUD P1battleHUD;
    public BattleHUD P2battleHUD;
    public BattleHUD CurrbattleHUD;
    public BattleHUD EnebattleHUD;
    public GameState BattleGameState;
    public GameManager MainGameManager;

    //Floating Text Game Object
    public GameObject FloatingDMGText;
    public GameObject FloatingDEFText;
    //RayCast Variable
    public float rayLength;
    public LayerMask layermask;

    //Totem Game Objects & Variables
    public Totem ActiveTotem;
    public Totem EnemyTotem;
    public Totem Selectedtotem;
    public bool hasAttacked = false;
    public GameObject[] Totems;

    //Totem Element Variables
    Element Acttotemelementtype;
    Element Enetotemelementtype;

    public Material HighlightedMat;
    public Material EneMat;
    public Material Player1Mat;
    public Material Player2Mat;
    public Material TotemOrginalMat;
    Renderer r;
    Material m;
    Material hm;


    public void setGameState()
    {

        BattleGameState = MainGameManager.gameState;
        hasAttacked = false;

        ClearSelection();


    }

    void Update()
    {
        Selection();
        switch (BattleGameState)
        {
          
            case GameState.PLAYER_1_TURN:
                CurrbattleHUD = P1battleHUD;
                EnebattleHUD = P2battleHUD;
                break;
            case GameState.PLAYER_2_TURN:
                CurrbattleHUD = P2battleHUD;
                EnebattleHUD = P1battleHUD;
                break;
            
        }

        



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
                
    
                Selectedtotem = rhInfo.collider.gameObject.GetComponent<Totem>();
                Debug.Log(rhInfo.collider.name);
                FindObjectOfType<SoundManager>().Play("SelectAudio");
                switch (BattleGameState)
                {

                    case GameState.PLAYER_1_TURN:
                        switch (Selectedtotem.totemIs)
                        {
                            case WhatisTotem.O:
                                ActiveTotem = Selectedtotem;
                                
                                ActiveTotem.GetComponentInChildren<Renderer>().material = HighlightedMat;
                                CurrbattleHUD.SetHUD(ActiveTotem);

                                break;
                            case WhatisTotem.X:
                                EnemyTotem = Selectedtotem;
                                
                                EnemyTotem.GetComponentInChildren<Renderer>().material = EneMat;
                                EnebattleHUD.SetHUD(EnemyTotem);
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
                                
                                ActiveTotem.GetComponentInChildren<Renderer>().material = HighlightedMat;
                                CurrbattleHUD.SetHUD(ActiveTotem);
                                break;
                            case WhatisTotem.O:
                                EnemyTotem = Selectedtotem;
                                EnemyTotem.GetComponentInChildren<Renderer>().material = EneMat;
                                EnebattleHUD.SetHUD(EnemyTotem);
                                break;
                            default:
                                break;
                        }

                       

                        break;

                }


            }


            else
            {




                ClearOtherSelection();
                ClearSelection();
                Debug.Log("Nothing");
            }

        }






    }

    void ShowDMGFloatingText(Vector3 postion)
    {
        postion.y = 30f;
        var go = Instantiate(FloatingDMGText, postion, Quaternion.Euler(new Vector3(45, -90, 0)));
        go.GetComponent<TextMesh>().text = "- " + ActiveTotem.totemCurrentDamage.ToString() + " Hp";
    }

    void ShowDEFFloatingText(Vector3 postion)
    {
        postion.y = 30f;
        var go = Instantiate(FloatingDEFText, postion, Quaternion.Euler(new Vector3(45, -90, 0)));
        go.GetComponent<TextMesh>().text = "+ " + ActiveTotem.totemDefence.ToString() + " Def";
    }

    public void ClearSelection()
    {
        Totems = GameObject.FindGameObjectsWithTag("Totem");

        foreach (GameObject Totem in Totems)
        {
            Totem.GetComponentInChildren<Renderer>().material = Totem.GetComponentInChildren<Totem>().TotemMat;
        }
        EnebattleHUD.ResetHUD(EnemyTotem );
        CurrbattleHUD.ResetHUD(ActiveTotem);
        EnemyTotem = null;
        ActiveTotem = null;
        Selectedtotem = null;
       
        ClearOtherSelection();
    }
    public void ClearOtherSelection()
    {
        Totems = GameObject.FindGameObjectsWithTag("Totem");

        foreach (GameObject Totem in Totems)
        {
            if (Totem != ActiveTotem || EnemyTotem)
            {
                Totem.GetComponentInChildren<Renderer>().material = Totem.GetComponentInChildren<Totem>().TotemMat;
            }
            
          
        }
       

    }

    public void OnAttackButton()
    {
        if (EnemyTotem == null)
            return;
       
        if (ActiveTotem.hasAttack == false)
        {
           
            EnebattleHUD.SetHUD(EnemyTotem);        
            switch (ActiveTotem.TotemElementType)
            {
                case Element.Fire:
                    if (EnemyTotem.TotemElementType == Element.Earth)
                    {
                        PlayAttackSound(ActiveTotem);
                        EnemyTotem.TakeCritDamage(ActiveTotem,EnemyTotem);
                        EnebattleHUD.SetHUD(EnemyTotem);
                    }
                    else
                    {
                        PlayAttackSound(ActiveTotem);
                        EnemyTotem.TakeDamage(ActiveTotem, EnemyTotem);
                        EnebattleHUD.SetHUD(EnemyTotem);
                    }
                    break;
                case Element.Water:
                    if (EnemyTotem.TotemElementType == Element.Fire)
                    {
                        PlayAttackSound(ActiveTotem);
                        EnemyTotem.TakeCritDamage(ActiveTotem, EnemyTotem);
                        EnebattleHUD.SetHUD(EnemyTotem);

                    }
                    else
                    {
                        PlayAttackSound(ActiveTotem);
                        EnemyTotem.TakeDamage(ActiveTotem, EnemyTotem);
                        EnebattleHUD.SetHUD(EnemyTotem);
                    }
                    break;
                case Element.Earth:
                    if (EnemyTotem.TotemElementType == Element.Water)
                    {
                        PlayAttackSound(ActiveTotem);
                        EnemyTotem.TakeCritDamage(ActiveTotem, EnemyTotem);
                        EnebattleHUD.SetHUD(EnemyTotem);
                    }
                    else
                    {
                        PlayAttackSound(ActiveTotem);
                        EnemyTotem.TakeDamage(ActiveTotem, EnemyTotem);
                        EnebattleHUD.SetHUD(EnemyTotem);
                    }
                    break;
                case Element.Air:
                    if (EnemyTotem.TotemElementType == Element.Air)
                    {
                        PlayAttackSound(ActiveTotem);
                        EnemyTotem.TakeCritDamage(ActiveTotem, EnemyTotem);
                        EnebattleHUD.SetHUD(EnemyTotem);
                    }
                    else
                    {
                        PlayAttackSound(ActiveTotem);
                        EnemyTotem.TakeDamage(ActiveTotem, EnemyTotem);
                        EnebattleHUD.SetHUD(EnemyTotem);
                    }
                    break;
                default:

                    break;

            }
            ShowDMGFloatingText(EnemyTotem.transform.position);
            if (EnemyTotem.IsDead)
            {
                EnebattleHUD.ResetHUD(EnemyTotem);
                EnemyTotem = null; 
            }

            else
                EnebattleHUD.SetHUD(EnemyTotem);
            
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
            ActiveTotem.TotemDefend(ActiveTotem);
            CurrbattleHUD.SetHUD(ActiveTotem);
            ShowDEFFloatingText(ActiveTotem.transform.position);
            if (ActiveTotem.totemCurrentHP <= 0)
                Destroy(ActiveTotem.gameObject);

            else
                CurrbattleHUD.SetHUD(ActiveTotem);
            return;



        }
        else
            return;

    }
    public void PlayAttackSound(Totem totem)
    {

        Debug.Log("Sound");
        switch (totem.TotemElementType)
        {
            case Element.Fire:
                FindObjectOfType<SoundManager>().Play("FireTotemAtkAudio");
                break;
            case Element.Water:
                FindObjectOfType<SoundManager>().Play("WaterTotemAtkAudio");
                break;
            case Element.Earth:
                FindObjectOfType<SoundManager>().Play("EarthTotemAtkAudio");
                break;
            case Element.Air:
                FindObjectOfType<SoundManager>().Play("AirTotemAtkAudio");
                break;
            default:
                break;
        }

    }


}



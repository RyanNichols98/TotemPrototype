using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;



public class BattleManager : MonoBehaviour
{
    public BattleHUD battleHUD;

    public float rayLength;
    public LayerMask layermask;
    public Totem[,] Totems { set; get;}
    public Totem ActiveTotem;
    public Totem EnemyTotem;
    public GameState BattleGameState;





    void setGameState()
    {







    }

    void Update()
    {

        setGameState();

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            //bool didHit = Physics.Raycast(toMouse, out rhInfo, 500.0f);
            if (Physics.Raycast(toMouse, out rhInfo, rayLength, layermask))
            {

                var Selectedtotem = rhInfo.collider.gameObject.GetComponent<Totem>();
                Debug.Log(rhInfo.collider.name);
                ActiveTotem = Selectedtotem;
                battleHUD.SetHUD(ActiveTotem);

            }
            else
            {
                ClearSelection();
                Debug.Log("Nothing");
            }

        }

       


    }

    void Selection()
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
                ActiveTotem = Selectedtotem;
            }
            else
            {
                ClearSelection();
                Debug.Log("Nothing");
            }

        }

        battleHUD.SetHUD(ActiveTotem);





    }
    void CurrentGameState()
    {




    }

    void ClearSelection()
    {

        ActiveTotem = null;
    }
    
    public void OnAttackButton()
    {
        switch (BattleGameState)
        {
            
            case GameState.PLAYER_1_TURN:
                if (ActiveTotem.isCross == true)
                {
                    EnemyTotem.TakeDamage();
                    battleHUD.SetHUD(EnemyTotem);
                    if (EnemyTotem.totemCurrentHP <= 0)
                        Destroy(EnemyTotem.gameObject);

                    else
                        battleHUD.SetHUD(EnemyTotem);
                    return;



                }
                else
                break;
            case GameState.PLAYER_2_TURN:
                if (ActiveTotem.isCross == false)
                {
                    EnemyTotem.TakeDamage();
                    battleHUD.SetHUD(EnemyTotem);
                    if (EnemyTotem.totemCurrentHP <= 0)
                        Destroy(EnemyTotem.gameObject);

                    else
                        battleHUD.SetHUD(EnemyTotem);
                    return;



                }
                else
                    break;
           
        }
        

        


    }

    public void OnDefendButton()
    {

        if (ActiveTotem.isDefending == false)
        {
            ActiveTotem.TotemDefend();
            battleHUD.SetHUD(ActiveTotem);
            if (ActiveTotem.totemCurrentHP <= 0)
                Destroy(ActiveTotem.gameObject);

            else
                battleHUD.SetHUD(ActiveTotem);
            return;

           

        }
        else
            return;

    }

    public void SendMessage()
    {


        GameObject.Find("Game Manager").SendMessage("EnableSquare", gameObject);



    }
}



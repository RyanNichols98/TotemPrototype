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
   
    

    


    void Update()
    {
      
        //ActiveTotem = totem.GetComponent<GameObject>();
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            //bool didHit = Physics.Raycast(toMouse, out rhInfo, 500.0f);
            if (Physics.Raycast(toMouse, out rhInfo,rayLength, layermask))
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
    


    void ClearSelection()
    {

        ActiveTotem = null;
    }
    
    public void OnAttackButton()
    {

        if(ActiveTotem.isCross = true)
        {
            ActiveTotem.totemCurrentHP = 1;
            battleHUD.SetHUD(ActiveTotem);
            return;
            
        }

    }

}



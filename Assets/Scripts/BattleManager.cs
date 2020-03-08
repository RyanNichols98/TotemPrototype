using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class BattleManager : MonoBehaviour
{


    public Totem[,] Totems { set; get;}
    public GameObject ActiveTotem;
   
    public Transform player1plane;
    public Transform player2plane;

    


    void Update()
    {
        //ActiveTotem = totem.GetComponent<GameObject>();

    }
    void SelectObject(GameObject obj)
    {
            if (Input.GetMouseButtonDown(0))
            {
                Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit rhInfo;
                bool didHit = Physics.Raycast(toMouse, out rhInfo, 500.0f);
                if (didHit)
                {

                    Debug.Log(rhInfo.collider.name);
                    ActiveTotem = rhInfo.transform.root.gameObject;

                    
                }
                else
                {

                    Debug.Log("Nothing");
                }

            }

        if (ActiveTotem != null)
        {

            if (obj == ActiveTotem)
            {
                return;
                ClearSelection();
            }
            ActiveTotem = obj;
        }

        Renderer[] rs = ActiveTotem.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {


            Material m = r.material;
            m.color = Color.red;


        }


    }


    void ClearSelection()
    {

        ActiveTotem = null;
    }

}



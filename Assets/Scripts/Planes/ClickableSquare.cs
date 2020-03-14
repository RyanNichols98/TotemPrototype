using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Element { Fire, Water, Earth, Air }

public class ClickableSquare : MonoBehaviour
{
    public Element PlaneType;
    public int SquareNumber = 0;
    public bool IsPlaneOcc = false;
    
    void OnMouseDown()
    {

        if (IsPlaneOcc == false)
        {

            GameObject.Find("Game Manager").SendMessage("SquareClicked", gameObject);
            
        }

        if (IsPlaneOcc == true)
        {
            return;
        }




    }
    public void EnableSquare()
    {
        Debug.Log(SquareNumber + " is claimable");

        IsPlaneOcc = false;





    }


}

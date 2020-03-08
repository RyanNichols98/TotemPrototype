using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element { Fire, Water, Earth, Air }

public class ClickableSquare : MonoBehaviour
{
    public Element PlaneType;
    public int SquareNumber = 0;
    
    void OnMouseDown()
    {
       
        GameObject.Find("Game Manager").SendMessage("SquareClicked", gameObject);
        Destroy(this);
        


    }

  

}

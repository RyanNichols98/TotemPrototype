using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableSquare : MonoBehaviour
{

    public int SquareNumber = 0;

    void OnMouseDown()
    {

        GameObject.Find("Game Manager").SendMessage("SquareClicked", gameObject);
        Destroy(this);

    }


}

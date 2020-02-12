using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour { 


    // These are for Object Prefabs
    public GameObject Naught;
    public GameObject Cross;


    // Turn tells us who's turn it is( 1= 0 2= x)
    int Turn = 1;




    public void SquareClicked(GameObject square)
    {

        //Get the square number
        int SquareNumber = square.GetComponent<ClickableSquare>().SquareNumber;

        print(SquareNumber);

        SpawnPrefab(square.transform.position);

        //Next player turn
        NextTurn();

    }






    void SpawnPrefab(Vector3 postion)
    {

        // So we can see it
        //postion.z = 0;
        //Check who's turn it is, then sqawn their prefab
        if (Turn == 1)
            Instantiate(Naught, postion, Quaternion.identity);
        else if (Turn == 2)
            Instantiate(Cross, postion, Quaternion.identity);


    }

    void NextTurn()
    {

        //Increase Turn
        Turn += 1;

        //Check if Turn hit 3

        if (Turn == 3)
            Turn = 1;


    }
}

using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour { 


    // These are for Object Prefabs
    public GameObject Naught;
    public GameObject Cross;
    
    // TurnCounter
    int turnCounter = 0;
    public Text TurnText;

    int player1 = 1;
    int player2 = 2;

    // Squares tells us who owns which square in the game
    int[] squares = new int [9];

    // Turn tells us who's turn it is( 1= 0 2= x)
    int PlayerTurn = 1;

    //Contains winner naught = 1 / cross = 2 / draw = 3
    int Winner = 0;

    //Contains amount of click on a square
    int ClickCount = 0;

    public void Update()
    {
        SetTurnText();
    }
    
    public void SquareClicked(GameObject square)
    {
        // adding a turn
        
        SetTurnText();
        //Get the square number
        int SquareNumber = square.GetComponent<ClickableSquare>().SquareNumber;

      
        //increase click count
        ClickCount += 1;

        
        //Create the prefab for the click
        SpawnPrefab(square.transform.position);

        // make the player own the square
        squares[SquareNumber] = PlayerTurn;

        //Check for a winner
        CheckForWinner();


        //Next player turn
        NextTurn();

       
    }


    void SetTurnText ()
    {

        // Text object equal to string and turnCounter

        TurnText.text = "Turn: " + turnCounter.ToString();



    }

    void CheckForWinner()
    {

        for (int player = 1; player <= 2; player++)
        {

            // First Row
            if (squares[0] == player && squares[1] == player & squares[2] == player)
            {
                DisableSquares();
                print(player + "Wins!");
                Winner = player;
            }
            // Seccond Row
            else if (squares[3] == player && squares[4] == player & squares[5] == player)
            {
                DisableSquares();
                print(player + " Wins!");
                Winner = player;
            }

            // Third Row
            else if (squares[6] == player && squares[7] == player & squares[8] == player)
            {
                DisableSquares();
                print(player + " Wins!");
                Winner = player;
            }

            // First Column
            else if (squares[0] == player && squares[3] == player & squares[6] == player)
            {
                DisableSquares();
                print(player + " Wins!");
                Winner = player;
            }
            // Seccond Column
            else if (squares[1] == player && squares[4] == player & squares[7] == player)
            {
                DisableSquares();
                print(player + " Wins!");
                Winner = player;
            }

            // Third Column
            else if (squares[2] == player && squares[5] == player & squares[8] == player)
            {
                DisableSquares();
                print(player + " Wins!");
                Winner = player;
            }


            // Right Diagonal 
            else if (squares[0] == player && squares[4] == player & squares[8] == player)
            {
                DisableSquares();
                print(player + " Wins!");
                Winner = player;
            }

            // Left Diagonal 
            else if (squares[2] == player && squares[4] == player & squares[6] == player)
            {
                DisableSquares();
                print(player + " Wins!");
                Winner = player;
            }

        }


        // check for a draw
        if (ClickCount == 9 && Winner == 0)
        {
            Winner = 3;
        }
    }


    void DisableSquares()

    {
        // Destory remaing squares
        foreach(ClickableSquare square in GameObject.FindObjectsOfType<ClickableSquare>())
        {

            Destroy(square);
        }



    }
    void SpawnPrefab(Vector3 postion)
    {

        // So we can see it
        //postion.z = 0;
        //Check who's turn it is, then sqawn their prefab
        if (PlayerTurn == 1)
            Instantiate(Naught, postion, Quaternion.identity);
        else if (PlayerTurn == 2)
            Instantiate(Cross, postion, Quaternion.identity);

    }

    public void NextTurn()
    {
        //Increase Turn
        PlayerTurn += 1;

        //Check if Turn hit 3

        if (PlayerTurn == 3)
            PlayerTurn = 1;

        turnCounter += 1;
    }
    
    void OnGUI()

    {

        // Check if we have a winner
        if (Winner == 1)

        {

            //Winner is naught
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Naught is Winner!");


        }

        else if (Winner == 2)

        {

            //Winner is cross
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Cross is Winner!");


        }

        else if (Winner == 3)
        {

            //draw
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "It's a draw!");

        }

        // Checkk if the game is over
        if (Winner != 0)
        {

           if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 25, 100, 50), "Restart"))
            {

                SceneManager.LoadScene(0);

            }

        }


    }
}

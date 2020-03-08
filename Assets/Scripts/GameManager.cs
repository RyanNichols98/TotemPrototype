using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState { START, PLAYER_1_TURN, PLAYER_2_TURN, END }

public class GameManager : MonoBehaviour {

    //Game states
    public GameState gameState;

    //BattleHUD
    public BattleHUD battleHUD;

    //Prefabs for each Totem
    public Totem WaterTotem;
    public Totem AirTotem;
    public Totem FireTotem;
    public Totem EarthTotem;
    public Totem selectedTotem;
    public Totem[,] Totems { set; get; }
    //Totem element type
    Element totemElementType;

    // These are for Object Prefabs
    public GameObject Naught;
    public GameObject Cross;
    
    // TurnCounter
    int turnCounter = 0;
    public Text TurnText;
    public Text NextTurnText;

    public Image P1_Icon;
    public Image P2_Icon;
    //CombatLogText
    public Text CombatText;
    

    // Squares tells us who owns which square in the game
    int[] squares = new int [9];

    // Turn tells us who's turn it is( 1= 0 2= x)
    int PlayerTurn = 1;

    //Contains winner naught = 1 / cross = 2 / draw = 3
    int Winner = 0;

    //Contains amount of click on a square
    int ClickCount = 0;
    void Start()
    {
        //var choice = gameState = GameState.PLAYER_1_TURN;
        P2_Icon.enabled = false;    
        gameState = GameState.PLAYER_1_TURN;
    }
    public void Update()
    {
    
        SetTurnText();
        //Check for a winner
       
       
    }

   


 

    public void SquareClicked(GameObject square)
    {
        //Get the square number
        int SquareNumber = square.GetComponent<ClickableSquare>().SquareNumber;

      
        //increase click count
        ClickCount += 1;

        var ElementType = square.GetComponent<ClickableSquare>().PlaneType;

        totemElementType = ElementType;

        SpawnTotem(square.transform.position);

        //Create the prefab for the click
        SpawnPrefab(square.transform.position);

        battleHUD.SetHUD(selectedTotem);
        // make the player own the square
        squares[SquareNumber] = PlayerTurn;



        //Next player turn
        NextTurnClicked();
        CheckForWinner();
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
    void SpawnTotem(Vector3 postion)
    {

        if (totemElementType == Element.Air)
        {
            selectedTotem = AirTotem;
            Instantiate(selectedTotem, postion, Quaternion.identity);
            
        }
        else if (totemElementType == Element.Water)
        {
            selectedTotem = WaterTotem;
            Instantiate(selectedTotem, postion, Quaternion.identity);
        }
        else if (totemElementType == Element.Fire)
        {
            selectedTotem = FireTotem;
            Instantiate(selectedTotem, postion, Quaternion.identity);
        }
        else if (totemElementType == Element.Earth)
        {
            selectedTotem = EarthTotem;
            Instantiate(selectedTotem, postion, Quaternion.identity);
        }


    }
    void SpawnPrefab(Vector3 postion)
    {

        // So we can see it
        //postion.z = 0;
        //Check who's turn it is, then sqawn their prefab
        if (gameState == GameState.PLAYER_1_TURN)
            {
            selectedTotem.isCross = true;
            Instantiate(Naught, postion, Quaternion.identity);
            }

        else if (gameState == GameState.PLAYER_2_TURN)
            {
            selectedTotem.isCross = false;
            Instantiate(Cross, postion, Quaternion.identity);
            }
    }

    public void NextTurn()
    {
        //Increase Turn
        PlayerTurn += 1;
       
        //Check if Turn hit 3

        if (PlayerTurn == 3)
            PlayerTurn = 1;

        turnCounter += 1;
        SetTurnText();
    }
    
    void OnGUI()

    {

        // Check if we have a winner
        if (Winner == 1)

        {

            //Winner is naught
            CombatText.text = "Naught is Winner!";
            NextTurnText.text = "Restart";
            P2_Icon.enabled = true;
            P1_Icon.enabled = false;
        }

        else if (Winner == 2)

        {

            //Winner is cross
            CombatText.text = "Cross is Winner!";
            NextTurnText.text = "Restart";
            P2_Icon.enabled = false;
            P1_Icon.enabled = true;
        }

        else if (Winner == 3)
        {

            //draw
            CombatText.text = "It's a draw!";
            NextTurnText.text = "Restart";
            P2_Icon.enabled = false;
            P1_Icon.enabled = false;
        }

        // Checkk if the game is over
        if (Winner != 0)
        {
            gameState = GameState.END;
           

        }




    }
    public void NextTurnClicked()
    {
       
        if (gameState == GameState.PLAYER_1_TURN)
        {
            NextTurn();
            gameState = GameState.PLAYER_2_TURN;
            CombatText.text = "Player Two Turn";
            P1_Icon.enabled = false;
            P2_Icon.enabled = true;
        }
        else if (gameState == GameState.PLAYER_2_TURN)
        {
            NextTurn();
            gameState = GameState.PLAYER_1_TURN;
            CombatText.text = "Player One Turn";
            P1_Icon.enabled = true;
            P2_Icon.enabled = false;
        }
        else if (gameState == GameState.END)
        {
            SceneManager.LoadScene(0);
        }


    }

}

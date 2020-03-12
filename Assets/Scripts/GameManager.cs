using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState { START, PLAYER_1_TURN, PLAYER_2_TURN, END }

public class GameManager : MonoBehaviour
{

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
    //Totem element type
    Element totemElementType;

    // These are for Object Prefabs
    public GameObject Naught;
    public GameObject Cross;
    public bool isTotemPlaced = false;

    public float rayLength;
    public LayerMask layermask;
    public Totem ActiveTotem;

    // TurnCounter
    int turnCounter = 0;
    public Text TurnText;
    public Text NextTurnText;
    public Text CombatText;
    public Image P1_Icon;
    public Image P2_Icon;

    //CombatLogText




    // Squares tells us who owns which square in the game
    int[] squares = new int[9];

    // Turn tells us who's turn it is( 1= 0 2= x)
    int PlayerTurn = 1;

    //Contains winner naught = 1 / cross = 2 / draw = 3
    int Winner = 0;

    //Contains amount of click on a square
    int ClickCount = 0;
    void Start()
    {
        //var choice = gameState = GameState.PLAYER_1_TURN;

        switch (gameState)
        {
            case GameState.START:
                turnCounter = 1;
                gameState = GameState.PLAYER_1_TURN;             
                battleHUD.SetCombatText(gameState);
                break;

        }

    }
    public void Update()
    {

        SetTurnText();
        //Check for a winner

       
    }






    public void SquareClicked(GameObject square)
    {

        if (isTotemPlaced == false)
        {
            
            //increase click count
            ClickCount += 1;
            //Get the square number
            int SquareNumber = square.GetComponent<ClickableSquare>().SquareNumber;

            var Square = square.GetComponent<ClickableSquare>().gameObject;

            var ElementType = square.GetComponent<ClickableSquare>().PlaneType;

            square.GetComponent<ClickableSquare>().IsPlaneOcc = true;
            // squares[SquareNumber] = 0;
            // make the player own the square
            squares[SquareNumber] = PlayerTurn;

            totemElementType = ElementType;

            //spawn totem
            SpawnTotem(square.transform.position);
            selectedTotem.totemsquarenumber = SquareNumber;
            battleHUD.SetHUD(selectedTotem);
           
            CheckForWinner();

            //Next player turn
           

        }


    }


    void SetTurnText()
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

        if (ClickCount == 9 && Winner == 0)
        {

            Winner = 3;


        }
    }

    public void EnableSquare()
    {

        

        




    }

    void DisableSquares()

    {
        // Destory remaing squares
        foreach (ClickableSquare square in GameObject.FindObjectsOfType<ClickableSquare>())
        {

            Destroy(square);
        }



    }
    void SpawnTotem(Vector3 postion)
    {
      
       

        // selectedTotem.isTotemOcc = true;
        switch (totemElementType)
        {
            case Element.Fire:
                selectedTotem = FireTotem;
                Instantiate(selectedTotem, postion, Quaternion.identity);
                break;
            case Element.Water:
                selectedTotem = WaterTotem;
                Totem totem = Instantiate(selectedTotem, postion, Quaternion.identity);
                break;
            case Element.Earth:
                selectedTotem = EarthTotem;
                Instantiate(selectedTotem, postion, Quaternion.identity);
                break;
            case Element.Air:
                selectedTotem = AirTotem;
                Instantiate(selectedTotem, postion, Quaternion.identity);
                break;
            default:
                break;
        }

        postion.y = 35.0f;

        switch (gameState)
        {

            case GameState.PLAYER_1_TURN:
                selectedTotem.isCross = false;
                Instantiate(Naught, postion, Quaternion.identity);
                break;
            case GameState.PLAYER_2_TURN:
                selectedTotem.isCross = true;
                Instantiate(Cross, postion, Quaternion.identity);
                break;

        }
        isTotemPlaced = true;
    }
   

    public void NextTurn()
    {
        
        switch (gameState)
        {
            
            case GameState.PLAYER_1_TURN:
                PlayerTurn = 1;
                break;
            case GameState.PLAYER_2_TURN:
                PlayerTurn = 2;
                break;
         
        }

        
        turnCounter += 1;
        SetTurnText();

    }

    void OnGUI()

    {

        // Check if we have a winner
        if (Winner == 1)

        {
            gameState = GameState.END;
            //Winner is naught
            CombatText.text = "Naught is Winner!";
            NextTurnText.text = "Restart";
            P2_Icon.enabled = false;
            P1_Icon.enabled = true;
        }

        else if (Winner == 2)

        {
            gameState = GameState.END;
            //Winner is cross
            CombatText.text = "Cross is Winner!";
            NextTurnText.text = "Restart";
            P2_Icon.enabled = true;
            P1_Icon.enabled = false;
        }

        else if (Winner == 3)
        {
            gameState = GameState.END;
            //Winner is cross
            CombatText.text = "Draw";
            NextTurnText.text = "Restart";
            P2_Icon.enabled = false;
            P1_Icon.enabled = false;
        }


    }
    public void NextTurnClicked()
    {

        switch (gameState)
        {
            
            case GameState.START:
                break;
            case GameState.PLAYER_1_TURN:               
                gameState = GameState.PLAYER_2_TURN;     
                break;
            case GameState.PLAYER_2_TURN:
                gameState = GameState.PLAYER_1_TURN;                            
                break;
            case GameState.END:
                SceneManager.LoadScene(0);
                break;
            default:
                break;
        }
        isTotemPlaced = false;
        battleHUD.SetCombatText(gameState);
        NextTurn();

    }
}


    
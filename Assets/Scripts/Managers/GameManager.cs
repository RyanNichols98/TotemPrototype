﻿using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public enum GameState { START, PLAYER_1_TURN, PLAYER_2_TURN, PAUSED, END }

public class GameManager : MonoBehaviour
{

    //Player Stats
    public PlayerStats P1_Stats;
    public PlayerStats P2_Stats;

    //Game states
    public GameState gameState;

    //Battle Manager
    public BattleManager MainBattleManger;

    public WhatisTotem TotemIs = WhatisTotem.O;

    //Prefabs for each Totem
    public Totem WaterTotem;
    public Totem AirTotem;
    public Totem FireTotem;
    public Totem EarthTotem;
    public Totem selectedTotem;
    //Totem element type
    Element totemElementType;

    // These are for Object Prefabs
    public ClickableSquare[] Tiles;
    public bool isTotemPlaced = false;

    public float rayLength;
    public LayerMask layermask;

    int TileNumber;

    // TurnCounter

    //CombatLogText
    int turnCounter = 0;
    public Text TurnText;
    public Text NextTurnText;
    public Text CombatText;
    public Image P1_Icon;
    public Image P2_Icon;

    //BattleHUD
    public BattleHUD p1battleHUD;
    public BattleHUD p2battleHUD;



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


                P1_Stats.ResetAP();
                P2_Stats.ResetAP();
                turnCounter = 1;
                gameState = GameState.PLAYER_1_TURN;
                MainBattleManger.setGameState();
                SetCombatText();
                TotemIs = WhatisTotem.O;
        

    }
    public void Update()
    {

        SetTurnText();
        //Check for a winner

     
    }






    public void SquareClicked(GameObject square)
    {

       bool isplaneocc = square.GetComponent<ClickableSquare>().IsPlaneOcc;

        if (isplaneocc == false && isTotemPlaced == false && gameState != GameState.PAUSED)
        {
           
            MainBattleManger.ClearSelection();
            //increase click count
            ClickCount += 1;
            //Get the square number
            int SquareNumber = square.GetComponent<ClickableSquare>().SquareNumber;

            var Square = square.GetComponent<ClickableSquare>().gameObject;

            var ElementType = square.GetComponent<ClickableSquare>().PlaneType;

            square.GetComponent<ClickableSquare>().IsPlaneOcc = true;
            squares[SquareNumber] = PlayerTurn;

            totemElementType = ElementType;

            UnityEngine.Debug.Log(SquareNumber + " is set");
            TileNumber = SquareNumber;
           
            //spawn totem
            SpawnTotem(square.transform.position);
            selectedTotem.totemsquarenumber = square.GetComponent<ClickableSquare>();
            // selectedTotem.TotemTileNumber = SquareNumber;

           
           
            CheckForWinner();

            //Next player turn

            switch (gameState)
            {

                case GameState.PLAYER_1_TURN:
                    P1_Stats.UseAP();
                    break;
                case GameState.PLAYER_2_TURN:
                    P2_Stats.UseAP();
                    break;
            }



        }


    }


    void SetTurnText()
    {

        // Text object equal to string and turnCounter

        TurnText.text = "Turn: " + turnCounter.ToString();

        SetCombatText();

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
                selectedTotem.totemIs = TotemIs;
                selectedTotem.SetMat();
                selectedTotem.TotemTileNumber = TileNumber;
                selectedTotem = Instantiate(selectedTotem, postion, Quaternion.identity);          
                break;
            case Element.Water:
                selectedTotem = WaterTotem;
                selectedTotem.totemIs = TotemIs;
                selectedTotem.SetMat();
                selectedTotem.TotemTileNumber = TileNumber;
                selectedTotem = Instantiate(selectedTotem, postion, Quaternion.identity);              
                break;
            case Element.Earth:
                selectedTotem = EarthTotem;
                selectedTotem.totemIs = TotemIs;
                selectedTotem.SetMat();
                selectedTotem.TotemTileNumber = TileNumber;
                selectedTotem = Instantiate(selectedTotem, postion, Quaternion.identity);               
                break;
            case Element.Air:
                selectedTotem = AirTotem;
                selectedTotem.totemIs = TotemIs;
                selectedTotem.SetMat();
                selectedTotem.TotemTileNumber = TileNumber;
                selectedTotem =Instantiate(selectedTotem, postion, Quaternion.identity);
                break;
            default:
                break;
        }

       
        
        isTotemPlaced = true;
    }
    public void EnableTile(ClickableSquare tile)
    {
        tile.EnableSquare();
        squares[tile.SquareNumber] = 0;
    }

    public void NextTurn()
    {
        
        switch (gameState)
        {
            
            case GameState.PLAYER_1_TURN:
                PlayerTurn = 1;
                TotemIs = WhatisTotem.O;

                break;
            case GameState.PLAYER_2_TURN:
                PlayerTurn = 2;
                TotemIs = WhatisTotem.X;
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
            
            case GameState.PLAYER_1_TURN:               
                gameState = GameState.PLAYER_2_TURN;
                P2_Stats.ResetAP();
                break;
            case GameState.PLAYER_2_TURN:
                gameState = GameState.PLAYER_1_TURN;
                P1_Stats.ResetAP();
                break;
            case GameState.END:
                SceneManager.LoadScene(1);
                break;
          
        }
        MainBattleManger.setGameState();
        MainBattleManger.ClearSelection();
        isTotemPlaced = false;
        SetCombatText();
        NextTurn();
        FindObjectOfType<SoundManager>().Play("NewTurnAudio");
    }
    public void SetCombatText()
    {
        
        switch (gameState)
        {
            case GameState.START:
                break;
            case GameState.PLAYER_1_TURN:
                CombatText.text = "Player One Turn";          
                break;
            case GameState.PLAYER_2_TURN:
                CombatText.text = "Player Two Turn";            
                break;
            case GameState.END:
                break;
            default:
                break;
        }


    }
}


    
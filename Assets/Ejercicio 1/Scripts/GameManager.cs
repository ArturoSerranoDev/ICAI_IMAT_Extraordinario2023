using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SphereFactory sphereFactory;
    
    public Action<bool> OnVictory;
    
    // BOARD
    private const int rows = 6;
    private const int cols = 7;
    private int[,] board = new int[rows, cols];
    private List<int> spheresInColumn = new List<int> {0, 0, 0, 0, 0, 0, 0};
    
    // Define IDs for player and enemy to fill and analyze board matrix
    private const int emptyID = 0;
    private const int playerID = 1;
    private const int enemyID = 2;
    
    // STATE
    private TurnState playerTurn;
    private TurnState enemyTurn;
    private TurnState currentTurn;
    private bool isPlayerTurn = true;
    private void Start()
    {
        playerTurn = new PlayerTurn();
        enemyTurn = new EnemyTurn();
        currentTurn = playerTurn;
    }
    
    void Update()
    {
        if (isPlayerTurn)
        {
            if (WaitingForUserInput())
                return;
        }
        
        // Decision taken by state
        int columnChosen = currentTurn.ReturnColumnChosen();
        Debug.Log(columnChosen + "state " + currentTurn);

        Sphere newSphere = sphereFactory.CreateSphere(
            new Vector3(columnChosen,spheresInColumn[columnChosen - 1], 0),
            isPlayerTurn);
        
        // Update lists
        spheresInColumn[columnChosen - 1]++;
        board[columnChosen, spheresInColumn[columnChosen - 1]] = isPlayerTurn ? playerID : enemyID;
        
        Debug.Log("New sphere at x" + columnChosen + " y " + spheresInColumn[columnChosen - 1] + "belonging to" +
            board[columnChosen, spheresInColumn[columnChosen - 1]]);
        
        // Check win condition
        bool gameEnded = CheckWinCondition(out bool isPlayerVictory);
        if (gameEnded)
        { 
            OnVictory?.Invoke(isPlayerVictory);
        }
        
        // Switch the state
        isPlayerTurn = !isPlayerTurn;
        currentTurn = isPlayerTurn ? playerTurn : enemyTurn;
    }
    private static bool WaitingForUserInput()
    {
        while (!Input.anyKeyDown)
            return true;
        return false;
    }
    
    private bool CheckWinCondition(out bool isPlayerVictory)
    {
        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                int winner = board[row, col];
                if (winner == 0) continue;

                // Check horizontally
                if (col <= board.GetLength(1) - 4 && 
                    winner == board[row, col + 1] && 
                    winner == board[row, col + 2] && 
                    winner == board[row, col + 3])
                {
                    isPlayerVictory = winner == playerID ? true : false; 
                    return true;
                }

                // Check vertically
                if (row <= board.GetLength(0) - 4 && 
                    winner == board[row + 1, col] &&
                    winner == board[row + 2, col] &&
                    winner == board[row + 3, col])
                {
                    isPlayerVictory = winner == playerID ? true : false; 
                    return true;
                }

                // Check diagonal (bottom-left to top-right)
                if (row <= board.GetLength(0) - 4 &&
                    col <= board.GetLength(1) - 4 &&
                    winner == board[row + 1, col + 1] &&
                    winner == board[row + 2, col + 2] &&
                    winner == board[row + 3, col + 3])
                {
                    isPlayerVictory = winner == playerID ? true : false; 
                    return true;
                }

                // Check diagonal (top-left to bottom-right)
                if (row >= 3 && col <= board.GetLength(1) - 4 &&
                    winner == board[row - 1, col + 1] &&
                    winner == board[row - 2, col + 2] &&
                    winner == board[row - 3, col + 3])
                {
                    isPlayerVictory = winner == playerID ? true : false; 
                    return true;
                }
            }
        }

        isPlayerVictory = false; 
        return false;
    }
}

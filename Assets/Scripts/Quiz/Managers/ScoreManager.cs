using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int player1Score;
    public int player2Score;
    public int player3Score;
    public int player4Score;

    public void AddScore(int playerNumber, int score)
    {
        switch (playerNumber)
        {
            case 1:
                player1Score += score;
                Debug.Log("Player 1 Score: " + player1Score);
                break;
            case 2:
                player2Score += score;
                Debug.Log("Player 2 Score: " + player2Score);
                break;
            case 3:
                player3Score += score;
                Debug.Log("Player 3 Score: " + player3Score);
                break;
            case 4:
                player4Score += score;
                Debug.Log("Player 4 Score: " + player4Score);
                break;
        }
    }
}
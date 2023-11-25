using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    public int correctAnswer;

    [Space]
    public ScoreManager scoreManager;

    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;

    private void Start()
    {
        correctAnswer = 1;
        Invoke("AnswerCheck", 10);
    }

    public void AnswerCheck()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player3 = GameObject.FindGameObjectWithTag("Player3");
        player4 = GameObject.FindGameObjectWithTag("Player4");

        if (player1.GetComponent<PlayerController>().answerChosed == correctAnswer)
        {
            scoreManager.AddScore(scoreManager.player1Score);
        }

        //if (player2.GetComponent<PlayerController>().answerChosed == correctAnswer)
        //{
        //    scoreManager.AddScore(scoreManager.player2Score);
        //}

        //if (player3.GetComponent<PlayerController>().answerChosed == correctAnswer)
        //{
        //    scoreManager.AddScore(scoreManager.player3Score);
        //}

        //if (player4.GetComponent<PlayerController>().answerChosed == correctAnswer)
        //{
        //    scoreManager.AddScore(scoreManager.player4Score);
        //}
    }
}

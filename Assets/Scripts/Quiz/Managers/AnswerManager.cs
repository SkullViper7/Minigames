using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    public List<int> correctAnswers;
    public int correctAnswer;

    [Space]
    public ScoreManager scoreManager;
    public QuestionManager questionManager;
    public AnswerTextManager answerTextManager;

    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;

    private void Start()
    {
        Invoke("AnswerCheck", 3);
    }

    public void AnswerCheck()
    {
        correctAnswer = correctAnswers[questionManager.questionPicked];

        if (GameManager.Instance.maxPlayerCount == 2)
        {
            player1 = GameObject.FindGameObjectWithTag("Player1");
            player2 = GameObject.FindGameObjectWithTag("Player2");

            if (player1.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(scoreManager.player1Score);
            }

            if (player2.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(scoreManager.player2Score);
            }
        }

        if (GameManager.Instance.maxPlayerCount == 3)
        {
            player1 = GameObject.FindGameObjectWithTag("Player1");
            player2 = GameObject.FindGameObjectWithTag("Player2");
            player3 = GameObject.FindGameObjectWithTag("Player3");

            if (player1.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(scoreManager.player1Score);
            }

            if (player2.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(scoreManager.player2Score);
            }

            if (player3.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(scoreManager.player3Score);
            }
        }

        if (GameManager.Instance.maxPlayerCount == 4)
        {
            player1 = GameObject.FindGameObjectWithTag("Player1");
            player2 = GameObject.FindGameObjectWithTag("Player2");
            player3 = GameObject.FindGameObjectWithTag("Player3");
            player4 = GameObject.FindGameObjectWithTag("Player4");

            if (player1.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(scoreManager.player1Score);
            }

            if (player2.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(scoreManager.player2Score);
            }

            if (player3.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(scoreManager.player3Score);
            }

            if (player4.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(scoreManager.player4Score);
            }
        }

        LoadNextQuestion();
    }

    void LoadNextQuestion()
    {
        int questionPicked = Random.Range(0, questionManager.questions.Count);
        questionManager.QuestionWrite(questionManager.questions[questionPicked]);
        answerTextManager.AnswerWrite(answerTextManager.firstAnswer[questionPicked],
            answerTextManager.secondAnswer[questionPicked],
            answerTextManager.thirdAnswer[questionPicked],
           answerTextManager.fourthAnswer[questionPicked]);

        Invoke("AnswerCheck", 3);
    }
}
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
        if (GameManager.Instance.maxPlayerCount == 2)
        {
            player1 = GameObject.FindGameObjectWithTag("Player1");
            player2 = GameObject.FindGameObjectWithTag("Player2");
        }
        if (GameManager.Instance.maxPlayerCount == 3)
        {
            player1 = GameObject.FindGameObjectWithTag("Player1");
            player2 = GameObject.FindGameObjectWithTag("Player2");
            player3 = GameObject.FindGameObjectWithTag("Player3");
        }
        if (GameManager.Instance.maxPlayerCount == 4)
        {
            player1 = GameObject.FindGameObjectWithTag("Player1");
            player2 = GameObject.FindGameObjectWithTag("Player2");
            player3 = GameObject.FindGameObjectWithTag("Player3");
            player4 = GameObject.FindGameObjectWithTag("Player4");
        }

        Invoke("AnswerCheck", 10);
    }

    private void Update()
    {
        correctAnswer = correctAnswers[questionManager.questionPicked];
    }

    public void AnswerCheck()
    {
        if (GameManager.Instance.maxPlayerCount == 2)
        {
            if (player1.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(1, 1);
            }

            if (player2.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(2, 1);
            }
        }

        if (GameManager.Instance.maxPlayerCount == 3)
        {
            if (player1.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(1,  1);
            }

            if (player2.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(2, 1);
            }

            if (player3.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(3, 1);
            }
        }

        if (GameManager.Instance.maxPlayerCount == 4)
        {
            if (player1.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(1, 1);
            }

            if (player2.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(2, 1);
            }

            if (player3.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(3, 1);
            }

            if (player4.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(4, 1);
            }
        }

        correctAnswers.Remove(correctAnswer);

        LoadNextQuestion();
    }

    void LoadNextQuestion()
    {
        if (GameManager.Instance.maxPlayerCount == 2)
        {
            player1.GetComponent<PlayerController>().answerChosed = 0;
            player2.GetComponent<PlayerController>().answerChosed = 0;
        }
        if (GameManager.Instance.maxPlayerCount == 3)
        {
            player1.GetComponent<PlayerController>().answerChosed = 0;
            player2.GetComponent<PlayerController>().answerChosed = 0;
            player3.GetComponent<PlayerController>().answerChosed = 0;
        }
        if (GameManager.Instance.maxPlayerCount == 4)
        {
            player1.GetComponent<PlayerController>().answerChosed = 0;
            player2.GetComponent<PlayerController>().answerChosed = 0;
            player3.GetComponent<PlayerController>().answerChosed = 0;
            player4.GetComponent<PlayerController>().answerChosed = 0;
        }

        int questionPicked = Random.Range(0, questionManager.questions.Count);
        questionManager.QuestionWrite(questionManager.questions[questionPicked]);
        answerTextManager.AnswerWrite(answerTextManager.firstAnswer[questionPicked],
            answerTextManager.secondAnswer[questionPicked],
            answerTextManager.thirdAnswer[questionPicked],
           answerTextManager.fourthAnswer[questionPicked]);

        Invoke("AnswerCheck", 10);
    }
}
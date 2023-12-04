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
    public CorrectAnswerBlink blink;

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

    public void UpdateCorrectAnswer()
    {
        correctAnswer = correctAnswers[questionManager.questionPicked];
    }

    public void AnswerCheck()
    {
        blink.pause = true;

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

        if (correctAnswer == 1)
        {
            StartCoroutine(blink.Blink(blink.answer1, blink.icon1, blink.text1));
        }
        if (correctAnswer == 2)
        {
            StartCoroutine(blink.Blink(blink.answer2, blink.icon2, blink.text2));
        }
        if (correctAnswer == 3)
        {
            StartCoroutine(blink.Blink(blink.answer3, blink.icon3, blink.text3));
        }
        if (correctAnswer == 4)
        {
            StartCoroutine(blink.Blink(blink.answer4, blink.icon4, blink.text4));
        }

        correctAnswers.Remove(correctAnswer);

        Invoke("LoadNextQuestion", 3);
    }

    void LoadNextQuestion()
    {
        blink.pause = false;

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
        StartCoroutine(questionManager.QuestionWrite(questionManager.questions[questionPicked]));
        UpdateCorrectAnswer();
        answerTextManager.AnswerWrite(answerTextManager.firstAnswer[questionPicked],
            answerTextManager.secondAnswer[questionPicked],
            answerTextManager.thirdAnswer[questionPicked],
           answerTextManager.fourthAnswer[questionPicked]);

        Invoke("AnswerCheck", 10);
    }
}
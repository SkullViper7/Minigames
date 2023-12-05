using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    public List<int> correctAnswers;//List of all the correct answers for all the questions
    public int correctAnswer;//The correct answer for each question

    [Space]//References for all the other scripts needed
    public ScoreManager scoreManager;
    public QuestionManager questionManager;
    public AnswerTextManager answerTextManager;
    public CorrectAnswerBlink blink;

    GameObject player1;//Players
    GameObject player2;
    GameObject player3;
    GameObject player4;

    private void Start()
    {
        if (GameManager.Instance.maxPlayerCount == 2)//Searching for the right amount of players to avoid errors
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

        Invoke("AnswerCheck", 10);//Check for the player answer after a countdown
    }

    public void UpdateCorrectAnswer()//Get the index of the correct answer based on the index of the question randomly picked
    {
        correctAnswer = correctAnswers[questionManager.questionPicked];
    }

    public void AnswerCheck()
    {
        blink.isPaused = true;//Stops the timer

        if (GameManager.Instance.maxPlayerCount == 2)
        {
            if (player1.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(1, 1);//Calls the method to add 1 point to the correct player
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
            StartCoroutine(blink.Blink(blink.answer1, blink.icon1, blink.text1));//Animation to highlight the correct answer
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

        correctAnswers.Remove(correctAnswer);//Removing the answer from the list so it can't be picked randomly again

        Invoke("LoadNextQuestion", 3);//Waiting time before the next question
    }

    void LoadNextQuestion()
    {
        blink.isPaused = false;//Reseting timer

        if (GameManager.Instance.maxPlayerCount == 2)
        {
            player1.GetComponent<PlayerController>().answerChosed = 0;//Reseting the default answer for each player
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

        int questionPicked = Random.Range(0, questionManager.questions.Count);//Picking a random question
        StartCoroutine(questionManager.QuestionWrite(questionManager.questions[questionPicked]));//Calling the method to write the question based on the random index
        UpdateCorrectAnswer();//Update the correct answer
        answerTextManager.AnswerWrite(answerTextManager.firstAnswer[questionPicked],//Calling the method to write the answers for the question picked
            answerTextManager.secondAnswer[questionPicked],
            answerTextManager.thirdAnswer[questionPicked],
           answerTextManager.fourthAnswer[questionPicked]);

        Invoke("AnswerCheck", 10);//Restarting countdown
    }
}
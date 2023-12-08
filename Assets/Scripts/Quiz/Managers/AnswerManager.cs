using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerManager : MonoBehaviour
{
    public List<int> correctAnswers;//List of all the correct answers for all the questions
    public int correctAnswer;//The correct answer for each question

    [Space]//References for all the other scripts needed
    public ScoreManager scoreManager;
    public QuestionManager questionManager;
    public AnswerTextManager answerTextManager;
    public CorrectAnswerBlink blink;
    public AudioManager audioManager;

    [Header("EndScreen")]
    public GameObject gameScreen;
    public GameObject endScreen;
    public LeaderboardManager leaderboardManager;

    GameObject player1;//Players
    GameObject player2;
    GameObject player3;
    GameObject player4;

    public int questionChosed;

    [Header("Audio")]
    public AudioClip voice;
    public AudioSource voiceSource;

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

        ChooseNextQuestion();
    }

    void ChooseNextQuestion()
    {
        blink.isPaused = false;

        int questionIndex = Random.Range(0, questionManager.questions.Count);
        questionManager.DisplayQuestion(questionIndex);
        audioManager.QuestionRead(questionIndex);

        StartCoroutine(answerTextManager.AnswerWrite(questionIndex));

        correctAnswer = correctAnswers[questionIndex];
        correctAnswers.Remove(questionIndex);

        Invoke("AnswerCheck", 10);
    }

    public void AnswerCheck()
    {
        int voiceIndex = Random.Range(0, audioManager.answerVoiced.Count);
        audioManager.AnswerRead(voiceIndex);

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

        if (questionManager.questions.Count > 29)
        {
            Invoke("ChooseNextQuestion", 3);//Waiting time before the next question
        }

        else
        {
            voiceSource.PlayOneShot(voice);
            gameScreen.SetActive(false);
            endScreen.SetActive(true);
            leaderboardManager.ShowScore();
        }
    }
}
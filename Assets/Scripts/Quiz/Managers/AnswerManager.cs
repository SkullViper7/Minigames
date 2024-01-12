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
    public AudioManager audioManager;
    public ClockManager clockManager;

    [Header("EndScreen")]
    public GameObject gameScreen;
    public GameObject endScreen;
    public LeaderboardManager leaderboardManager;

    List<GameObject> players = new List<GameObject>();

    public int questionChosed;
    int questionsAnswered = 0;

    [Header("Audio")]
    public AudioClip voice;
    public AudioClip applause;
    public AudioSource voiceSource;

    private void Start()
    {
        for (int i = 1; i <= GameManager.Instance.maxPlayerCount; i++)//Getting active players with their tag
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player" + i);
            players.Add(player);
        }

        ChooseNextQuestion();
    }

    void ChooseNextQuestion()//Calling all the methods displaying the questions and answers
    {
        blink.isPaused = false;
        audioManager.timer.Play();

        int questionIndex = Random.Range(0, questionManager.questions.Count);//Pick a random question
        string question = questionManager.GetQuestion(questionIndex);
        questionManager.DisplayQuestion(questionIndex);
        audioManager.QuestionRead(questionIndex);
        StartCoroutine(clockManager.TimeDecrease(questionIndex));

        StartCoroutine(answerTextManager.AnswerWrite(questionIndex, question));

        // Use the correct answer associated with the chosen question
        correctAnswer = correctAnswers[questionIndex];

        // Store the index of the chosen question for later use
        questionChosed = questionIndex;

        StartCoroutine(AnswerCheckWithDelay(audioManager.questionVoiced[questionIndex].length + 10));
    }


    IEnumerator AnswerCheckWithDelay(float delay)//Checks if the players chose the right answer and give them points
    {
        yield return new WaitForSeconds(delay);

        int currentQuestionIndex = questionChosed;

        blink.isPaused = true;

        if (currentQuestionIndex == questionChosed) // Check if the current question index matches
        {
            int voiceIndex = Random.Range(0, audioManager.answerVoiced.Count);
            audioManager.AnswerRead(voiceIndex);
        }

        // Retrieve the correct answer associated with the index of the chosen question
        correctAnswer = correctAnswers[questionChosed];

        // Check the answers for each player based on the chosen question
        for (int i = 1; i <= GameManager.Instance.maxPlayerCount; i++)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player" + i);
            if (player.GetComponent<PlayerController>().answerChosed == correctAnswer)
            {
                scoreManager.AddScore(i, 1);
            }
        }

        questionsAnswered++;

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

        // Delete the correct answer associated with the chosen question
        correctAnswers.RemoveAt(questionChosed);

        audioManager.timer.Stop();

        questionChosed = Random.Range(0, Mathf.Max(1, correctAnswers.Count));

        if (questionsAnswered >= 10)//Display leaderboard after the last question
        {
            StartCoroutine(DisplayLeaderboardAfterDelay());
        }
        else
        {
            Invoke("ChooseNextQuestion", 3); // Proceed to the next question
        }
    }

    IEnumerator DisplayLeaderboardAfterDelay()//Displays leaderboard
    {
        voiceSource.PlayOneShot(voice);
        voiceSource.PlayOneShot(applause);
        audioManager.timer.Stop();

        yield return new WaitForSeconds(3);

        gameScreen.SetActive(false);
        endScreen.SetActive(true);
        leaderboardManager.ShowScore();
    }
}
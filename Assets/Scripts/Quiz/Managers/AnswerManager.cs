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
    int questionsAnswered = 0;

    [Header("Audio")]
    public AudioClip voice;
    public AudioClip applause;
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
        string question = questionManager.GetQuestion(questionIndex);
        questionManager.DisplayQuestion(questionIndex);
        audioManager.QuestionRead(questionIndex);

        StartCoroutine(answerTextManager.AnswerWrite(questionIndex, question));
        // Utiliser la bonne réponse associée à la question choisie
        correctAnswer = correctAnswers[questionIndex];

        // Stocker l'index de la question choisie pour une utilisation ultérieure
        questionChosed = questionIndex;

        StartCoroutine(AnswerCheckWithDelay(audioManager.questionVoiced[questionIndex].length + 10));
    }


    IEnumerator AnswerCheckWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        int currentQuestionIndex = questionChosed;

        blink.isPaused = true;

        if (currentQuestionIndex == questionChosed) // Check if the current question index matches
        {
            int voiceIndex = Random.Range(0, audioManager.answerVoiced.Count);
            audioManager.AnswerRead(voiceIndex);

            // Rest of the existing code remains unchanged
        }

        // Récupérer la bonne réponse associée à l'index de la question choisie
        correctAnswer = correctAnswers[questionChosed];

        // Vérifier les réponses pour chaque joueur en fonction de la question choisie
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

        // Supprimer la réponse correcte associée à la question choisie
        correctAnswers.RemoveAt(questionChosed);

        questionChosed = Random.Range(0, Mathf.Max(1, correctAnswers.Count));

        if (questionsAnswered >= 10)
        {
            StartCoroutine(DisplayLeaderboardAfterDelay());
        }
        else
        {
            Invoke("ChooseNextQuestion", 3); // Proceed to the next question
        }
    }

    IEnumerator DisplayLeaderboardAfterDelay()
    {
        yield return new WaitForSeconds(3); // Adjust this delay as needed

        voiceSource.PlayOneShot(voice);
        voiceSource.PlayOneShot(applause);
        gameScreen.SetActive(false);
        endScreen.SetActive(true);
        leaderboardManager.ShowScore();
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public List<string> questions;

    public int questionPicked;

    [Space]
    public TMP_Text questionText;

    [Space]
    public AnswerManager answerManager;

    private void Start()
    {
        questionPicked = Random.Range(0, questions.Count);
        StartCoroutine(QuestionWrite(questions[questionPicked]));
        answerManager.UpdateCorrectAnswer();
    }

    public IEnumerator QuestionWrite(string question)
    {
        questionText.text = question;

        yield return new WaitForSeconds(0.5f);

        questions.Remove(question);
    }
}
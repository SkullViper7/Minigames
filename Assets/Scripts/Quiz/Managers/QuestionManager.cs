using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public List<string> questions;//List of questions

    [Space]
    public TMP_Text questionText;

    [Space]
    public AnswerManager answerManager;

    public void DisplayQuestion(int questionIndex)
    {
        questionText.text = questions[questionIndex];
        StartCoroutine(RemoveQuestion(questionIndex));
    }

    IEnumerator RemoveQuestion(int questionIndex)
    {
        yield return new WaitForSeconds(10);
        questions.RemoveAt(questionIndex);
    }
}
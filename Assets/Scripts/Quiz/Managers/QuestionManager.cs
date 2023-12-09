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

    public string GetQuestion(int questionIndex)//Get the current question picked by the AnswerManager
    {
        return questions[questionIndex];
    }

    public void DisplayQuestion(int questionIndex)//Display the question
    {
        questionText.text = questions[questionIndex];
        StartCoroutine(RemoveQuestion(questionIndex));
    }

    IEnumerator RemoveQuestion(int questionIndex)//Remove the question from the list to avoid picking it again
    {
        yield return new WaitForSeconds(10);
        questions.RemoveAt(questionIndex);
    }
}
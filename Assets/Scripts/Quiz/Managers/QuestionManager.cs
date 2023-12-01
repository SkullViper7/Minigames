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

    private void Start()
    {
        questionPicked = Random.Range(0, questions.Count);
        QuestionWrite(questions[questionPicked]);
    }

    public void QuestionWrite(string question)
    {
        questionText.text = question;
        questions.Remove(question);
    }
}
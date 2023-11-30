using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public string[] questions;
    public int questionNumber;

    [Space]
    public TMP_Text questionText;

    private void Start()
    {
        QuestionWrite(questions[questionNumber]);
    }

    public void QuestionWrite(string question)
    {
        questionText.text = question;
    }
}
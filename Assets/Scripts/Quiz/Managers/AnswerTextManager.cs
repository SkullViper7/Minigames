using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerTextManager : MonoBehaviour
{
    public string[] answer1;
    public string[] answer2;
    public string[] answer3;
    public string[] answer4;

    [Space]
    public TMP_Text answerText1; 
    public TMP_Text answerText2; 
    public TMP_Text answerText3; 
    public TMP_Text answerText4; 

    [Space]
    public QuestionManager questionManager;

    private void Start()
    {
        AnswerWrite(answer1[questionManager.questionNumber], answer2[questionManager.questionNumber], 
            answer3[questionManager.questionNumber], answer4[questionManager.questionNumber]);
    }

    public void AnswerWrite(string answer1, string answer2, string answer3, string answer4)
    {
        answerText1.text = answer1;
        answerText2.text = answer2;
        answerText3.text = answer3;
        answerText4.text = answer4;
    }
}

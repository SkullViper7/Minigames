using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerTextManager : MonoBehaviour
{
    public List<string> firstAnswer;//Lists of answers
    public List<string> secondAnswer;
    public List<string> thirdAnswer;
    public List<string> fourthAnswer;

    [Space]
    public TMP_Text answerText1; 
    public TMP_Text answerText2; 
    public TMP_Text answerText3; 
    public TMP_Text answerText4; 

    [Space]
    public QuestionManager questionManager;

    private void Start()
    {
        AnswerWrite(firstAnswer[questionManager.questionPicked], secondAnswer[questionManager.questionPicked], //Calling the method with the randomly picked index
            thirdAnswer[questionManager.questionPicked], fourthAnswer[questionManager.questionPicked]);
    }

    public void AnswerWrite(string answer1, string answer2, string answer3, string answer4)
    {
        answerText1.text = answer1;//Replacing current text with chosen answer
        answerText2.text = answer2;
        answerText3.text = answer3;
        answerText4.text = answer4;

        firstAnswer.Remove(answer1);//Removing the answer from the list to avoid picking it again
        secondAnswer.Remove(answer2);
        thirdAnswer.Remove(answer3);
        fourthAnswer.Remove(answer4);
    }
}
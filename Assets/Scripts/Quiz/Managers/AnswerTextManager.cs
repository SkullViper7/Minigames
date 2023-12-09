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
    public AnswerManager answerManager;

    public IEnumerator AnswerWrite(int questionIndex, string question)
    {
        // Stocks answers related to the question
        string currentFirstAnswer = firstAnswer[questionIndex];
        string currentSecondAnswer = secondAnswer[questionIndex];
        string currentThirdAnswer = thirdAnswer[questionIndex];
        string currentFourthAnswer = fourthAnswer[questionIndex];

        // Displaying answers
        answerText1.text = currentFirstAnswer;
        answerText2.text = currentSecondAnswer;
        answerText3.text = currentThirdAnswer;
        answerText4.text = currentFourthAnswer;

        // Match check with current question to hide incorrect answers 
        if (question != questionManager.GetQuestion(questionIndex))
        {
            answerText1.gameObject.SetActive(false);
            answerText2.gameObject.SetActive(false);
            answerText3.gameObject.SetActive(false);
            answerText4.gameObject.SetActive(false);
        }
        else
        {
            // If the question is correct show the answers
            answerText1.gameObject.SetActive(true);
            answerText2.gameObject.SetActive(true);
            answerText3.gameObject.SetActive(true);
            answerText4.gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(10);

        // Removes answers from the list to avoid picking them again
        firstAnswer.RemoveAt(questionIndex);
        secondAnswer.RemoveAt(questionIndex);
        thirdAnswer.RemoveAt(questionIndex);
        fourthAnswer.RemoveAt(questionIndex);
    }
}
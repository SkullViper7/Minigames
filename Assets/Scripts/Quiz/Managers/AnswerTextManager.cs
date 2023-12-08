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
        answerText1.text = firstAnswer[questionIndex];
        answerText2.text = secondAnswer[questionIndex];
        answerText3.text = thirdAnswer[questionIndex];
        answerText4.text = fourthAnswer[questionIndex];

        // Si la question affichée ne correspond pas à la question actuelle, cacher les réponses
        if (question != questionManager.GetQuestion(questionIndex))
        {
            answerText1.gameObject.SetActive(false);
            answerText2.gameObject.SetActive(false);
            answerText3.gameObject.SetActive(false);
            answerText4.gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(10);

        // Remove answers based on the index
        firstAnswer.RemoveAt(questionIndex);
        secondAnswer.RemoveAt(questionIndex);
        thirdAnswer.RemoveAt(questionIndex);
        fourthAnswer.RemoveAt(questionIndex);
    }
}
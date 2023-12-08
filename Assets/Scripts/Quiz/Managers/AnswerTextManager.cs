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
        // Stockage des r�ponses actuelles li�es � la question
        string currentFirstAnswer = firstAnswer[questionIndex];
        string currentSecondAnswer = secondAnswer[questionIndex];
        string currentThirdAnswer = thirdAnswer[questionIndex];
        string currentFourthAnswer = fourthAnswer[questionIndex];

        // Affichage des r�ponses
        answerText1.text = currentFirstAnswer;
        answerText2.text = currentSecondAnswer;
        answerText3.text = currentThirdAnswer;
        answerText4.text = currentFourthAnswer;

        // V�rification de correspondance avec la question actuelle pour masquer les r�ponses incorrectes
        if (question != questionManager.GetQuestion(questionIndex))
        {
            answerText1.gameObject.SetActive(false);
            answerText2.gameObject.SetActive(false);
            answerText3.gameObject.SetActive(false);
            answerText4.gameObject.SetActive(false);
        }
        else
        {
            // Si la question correspond, afficher les r�ponses
            answerText1.gameObject.SetActive(true);
            answerText2.gameObject.SetActive(true);
            answerText3.gameObject.SetActive(true);
            answerText4.gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(10);

        // Suppression des r�ponses en fonction de la question choisie
        firstAnswer.RemoveAt(questionIndex);
        secondAnswer.RemoveAt(questionIndex);
        thirdAnswer.RemoveAt(questionIndex);
        fourthAnswer.RemoveAt(questionIndex);
    }
}
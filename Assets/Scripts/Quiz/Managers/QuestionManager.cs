using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public List<string> questions;//List of questions

    public int questionPicked;//Index randomly picked for each question

    [Space]
    public TMP_Text questionText;

    [Space]
    public AnswerManager answerManager;

    private void Start()
    {
        questionPicked = Random.Range(0, questions.Count);//We pick a number randomly
        StartCoroutine(QuestionWrite(questions[questionPicked]));//Calling the method with the chosen index
        answerManager.UpdateCorrectAnswer();//Updating the correct answer
    }

    public IEnumerator QuestionWrite(string question)
    {
        questionText.text = question;//Replacing the default text with the question

        yield return new WaitForSeconds(0.5f);

        questions.Remove(question);//Removing the question from the list to avoid picking it again
    }
}
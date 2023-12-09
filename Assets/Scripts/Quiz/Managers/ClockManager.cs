using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    public TMP_Text time;
    public AudioManager audioManager;
    public AnswerManager answerManager;

    private void Start()
    {
        StartCoroutine(TimeDecrease());
    }

    IEnumerator TimeDecrease()
    {
        yield return new WaitForSeconds(audioManager.questionVoiced[answerManager.questionChosed].length);
        int count = 10;

        while (count >= 0)
        {
            time.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }

        yield return new WaitForSeconds(3); // Wait 3s between each question
        StartCoroutine(TimeDecrease()); // Restart countdown for the next question
    }
}
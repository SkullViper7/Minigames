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

    public IEnumerator TimeDecrease(int questionIndex)//Timer from 10 to 0
    {
        yield return new WaitForSeconds(audioManager.questionVoiced[questionIndex].length);//Starting after the voiceline
        int count = 10;

        while (count >= 0)
        {
            time.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CorrectAnswerBlink : MonoBehaviour
{
    [Header("Buttons")]
    public Image answer1;
    public Image answer2;
    public Image answer3;
    public Image answer4;

    [Header("Text")]
    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;
    public TMP_Text text4;

    [Header("Icons")]
    public Image icon1;
    public Image icon2;
    public Image icon3;
    public Image icon4;

    [Space]
    public bool pause;

    public IEnumerator Blink(Image answer, Image icon, TMP_Text text)
    {
        while (pause)
        {
            var answerColor = answer.color;
            var iconColor = icon.color;
            var textColor = text.color;
            iconColor.a = 0;
            textColor.a = 0;
            answerColor.a = 0;
            answer.color = answerColor;
            icon.color = iconColor;
            text.color = textColor;
            yield return new WaitForSeconds(0.25f);
            answerColor.a = 1;
            iconColor.a = 1;
            textColor.a = 1;
            answer.color = answerColor;
            icon.color = iconColor;
            text.color = textColor;
            yield return new WaitForSeconds(0.25f);
        }
    }
}

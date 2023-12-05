using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CorrectAnswerBlink : MonoBehaviour
{
    [Header("Buttons")] //Answer cards
    public Image answer1;
    public Image answer2;
    public Image answer3;
    public Image answer4;

    [Header("Text")]//Answer texts
    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;
    public TMP_Text text4;

    [Header("Icons")]//Controller icons
    public Image icon1;
    public Image icon2;
    public Image icon3;
    public Image icon4;

    [Space]
    public bool isPaused;//Tell when the answer is being reveiled between 2 questions

    public IEnumerator Blink(Image answer, Image icon, TMP_Text text)
    {
        while (isPaused)//Do this until the next question
        {
            var answerColor = answer.color;//Storing the actual color of the images
            var iconColor = icon.color;
            var textColor = text.color;

            iconColor.a = 0;//Setting the alpha to 0 to make them transparent
            textColor.a = 0;
            answerColor.a = 0;

            answer.color = answerColor;//Assigning the alpha to the images
            icon.color = iconColor;
            text.color = textColor;

            yield return new WaitForSeconds(0.25f);

            answerColor.a = 1;//Setting back the alpha to 1
            iconColor.a = 1;
            textColor.a = 1;

            answer.color = answerColor;
            icon.color = iconColor;
            text.color = textColor;

            yield return new WaitForSeconds(0.25f);
        }
    }
}

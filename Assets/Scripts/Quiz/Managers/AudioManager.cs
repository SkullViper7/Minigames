using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> questionVoiced;
    public List<AudioClip> answerVoiced;

    [Space]
    public AudioClip goodAnswer;
    public AudioClip badAnswer;
    public AudioClip applause;

    [Space]
    public AudioSource source;
    public AudioSource SFXsource;
    public AudioSource timer;

    public void QuestionRead(int questionIndex)
    {
        source.PlayOneShot(questionVoiced[questionIndex]);
        timer.mute = false;
        StartCoroutine(RemoveQuestionVoice(questionIndex));
    }

    IEnumerator RemoveQuestionVoice(int questionIndex)
    {
        yield return new WaitForSeconds(questionVoiced[questionIndex].length);
        yield return new WaitForSeconds(10);
        timer.mute = true;
        questionVoiced.Remove(questionVoiced[questionIndex]);
    }

    public void AnswerRead(int voiceIndex)
    {
        source.PlayOneShot(answerVoiced[voiceIndex]);
        if (voiceIndex == 3 || voiceIndex == 8)
        {
            SFXsource.PlayOneShot(badAnswer);
        }
        else
        {
            SFXsource.PlayOneShot(goodAnswer);
            SFXsource.PlayOneShot(applause);
        }

        StartCoroutine(RemoveAnswerVoice(voiceIndex));
    }

    IEnumerator RemoveAnswerVoice(int voiceIndex)
    {
        yield return new WaitForSeconds(3);
        answerVoiced.Remove(answerVoiced[voiceIndex]);
    }
}

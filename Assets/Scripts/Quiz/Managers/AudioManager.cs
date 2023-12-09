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

    bool isQuestionBeingRead = false;

    public void QuestionRead(int questionIndex)
    {
        if (questionIndex < questionVoiced.Count)
        {
            StartCoroutine(PlayQuestionWithDelay(questionIndex));
        }
        else
        {
            Debug.LogError("Question index out of range!");
        }
    }

    IEnumerator PlayQuestionWithDelay(int questionIndex)
    {
        isQuestionBeingRead = true;
        timer.mute = false;

        source.PlayOneShot(questionVoiced[questionIndex]);

        float audioLength = questionVoiced[questionIndex].length;

        yield return new WaitForSeconds(audioLength); // Wait for the audio to finish playing

        questionVoiced.RemoveAt(questionIndex); // Remove the played audio from the list

        isQuestionBeingRead = false;
    }

    public void AnswerRead(int voiceIndex)
    {
        if (voiceIndex < answerVoiced.Count) // Check if the index is within the answerVoiced list range
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
        else
        {
            Debug.LogError("Answer index out of range!");
        }
    }

    IEnumerator RemoveAnswerVoice(int voiceIndex)
    {
        if (voiceIndex < answerVoiced.Count) // Check if the index is within the answerVoiced list range
        {
            yield return new WaitForSeconds(3);

            answerVoiced.RemoveAt(voiceIndex);
        }
    }
}

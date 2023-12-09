using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> questionVoiced;//List of voicelines for the questions
    public List<AudioClip> answerVoiced;//List of voicelines for answers

    [Space]
    public AudioClip goodAnswer;
    public AudioClip badAnswer;
    public AudioClip applause;

    [Space]
    public AudioSource source;
    public AudioSource SFXsource;
    public AudioSource timer;

    bool isQuestionBeingRead = false;

    public void QuestionRead(int questionIndex)//Checks if the index of the question isn't greater than the list of voicelines
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

    IEnumerator PlayQuestionWithDelay(int questionIndex)//Plays the voiceline related to the question index
    {
        isQuestionBeingRead = true;

        source.PlayOneShot(questionVoiced[questionIndex]);

        float audioLength = questionVoiced[questionIndex].length;

        yield return new WaitForSeconds(audioLength); // Wait for the audio to finish playing

        questionVoiced.RemoveAt(questionIndex); // Remove the played audio from the list

        isQuestionBeingRead = false;
    }

    public void AnswerRead(int voiceIndex)//Plays the voiceline for he answer
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

            answerVoiced.RemoveAt(voiceIndex);//Removes the voiceline from the list so it can't be picked again
        }
    }
}

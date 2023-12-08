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
        source.PlayOneShot(questionVoiced[questionIndex]);

        isQuestionBeingRead = true;
        timer.mute = false;
        StartCoroutine(RemoveQuestionVoice(questionIndex));
    }

    IEnumerator RemoveQuestionVoice(int questionIndex)
    {
        yield return new WaitForSeconds(questionVoiced[questionIndex].length); // Attendre la dur�e de la question audio

        isQuestionBeingRead = false;
        if (!IsAnswerVoiceRemaining()) // V�rifier s'il n'y a plus de r�ponses audio � lire
        {
            timer.mute = true; // Arr�ter le timer si toutes les r�ponses ont �t� donn�es
        }
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
        yield return new WaitForSeconds(3); // Attendre la dur�e de l'audio de la r�ponse

        answerVoiced.Remove(answerVoiced[voiceIndex]);

        if (!isQuestionBeingRead && !IsAnswerVoiceRemaining()) // Si aucune question n'est en train d'�tre lue et qu'il n'y a plus de r�ponses audio
        {
            timer.mute = true; // Arr�ter le timer si aucune question n'est en cours et toutes les r�ponses ont �t� donn�es
        }
    }

    bool IsAnswerVoiceRemaining()
    {
        return answerVoiced.Count > 0;
    }
}

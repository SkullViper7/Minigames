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
        yield return new WaitForSeconds(questionVoiced[questionIndex].length); // Attendre la durée de la question audio

        isQuestionBeingRead = false;
        if (!IsAnswerVoiceRemaining()) // Vérifier s'il n'y a plus de réponses audio à lire
        {
            timer.mute = true; // Arrêter le timer si toutes les réponses ont été données
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
        yield return new WaitForSeconds(3); // Attendre la durée de l'audio de la réponse

        answerVoiced.Remove(answerVoiced[voiceIndex]);

        if (!isQuestionBeingRead && !IsAnswerVoiceRemaining()) // Si aucune question n'est en train d'être lue et qu'il n'y a plus de réponses audio
        {
            timer.mute = true; // Arrêter le timer si aucune question n'est en cours et toutes les réponses ont été données
        }
    }

    bool IsAnswerVoiceRemaining()
    {
        return answerVoiced.Count > 0;
    }
}

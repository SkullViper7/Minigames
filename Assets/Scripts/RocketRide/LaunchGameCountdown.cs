using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGameCountdown : MonoBehaviour
{
    private GameObject countdownWindow;
    [SerializeField]
    private GameObject gameWindow;
    [SerializeField]
    private AudioSource countDownAudioSource;
    private AudioSource mainAudioSource;
    private MainMusic mainMusic;

    [SerializeField]
    private AudioClip sfxAcute;
    [SerializeField]
    private AudioClip sfxGrave;


    private void Start()
    {
        countdownWindow = this.gameObject;
        mainAudioSource = GameObject.FindGameObjectWithTag("RocketRideMainMusic").GetComponent<AudioSource>();
        mainMusic = mainAudioSource.GetComponent<MainMusic>();
    }

    public void PlayAcute()
    {
        if (!mainMusic.musicIsAlreadyLaunch)
        {
            countDownAudioSource.clip = sfxAcute;
            countDownAudioSource.Play();
        }
    }

    public void PlayGrave()
    {
        if (!mainMusic.musicIsAlreadyLaunch)
        {
            countDownAudioSource.clip = sfxGrave;
            countDownAudioSource.Play();
        }
    }

    public void EndOfTheCountdown()
    {
        RocketRideManager.Instance.gameIsOver = false;
        gameWindow.SetActive(true);
        RocketRideChronoManager.Instance.StartChrono();
        if (!mainMusic.musicIsAlreadyLaunch)
        {
            mainMusic.musicIsAlreadyLaunch = true;
            mainAudioSource.Play();
        }
        countdownWindow.SetActive(false);
    }
}

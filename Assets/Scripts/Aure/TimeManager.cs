using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TimeManager : MonoBehaviour
{
    private static TimeManager _instance = null;
    public static TimeManager Instance => _instance;
    float timeMultiplicator;
    float timingToSpeedUp;
    public AudioSource music;
    public float totalScore;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
    }

    public void GameStart()
    {
        timeMultiplicator = 0.9f;
        timingToSpeedUp = 3;
        SpeedUp();
    }

    private void SpeedUp()
    {
        totalScore += timeMultiplicator;
        timeMultiplicator += 0.1f;
        timingToSpeedUp = 3 * timeMultiplicator;
        Time.timeScale = timeMultiplicator;
        music.pitch = 1 + (timeMultiplicator - 1) / 10; 
        Invoke("SpeedUp", timingToSpeedUp);
    }
}

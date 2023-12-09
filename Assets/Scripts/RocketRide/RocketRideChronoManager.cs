using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class RocketRideChronoManager : MonoBehaviour
{
    // Singleton
    private static RocketRideChronoManager _instance = null;
    private RocketRideChronoManager() { }
    public static RocketRideChronoManager Instance => _instance;
    //

    [SerializeField]
    private GameObject podiumScreen;
    [SerializeField]
    private GameObject gameScreen;

    [Header("ChronoTimer")]
    [SerializeField]
    private float time;
    [SerializeField]
    private TextMeshProUGUI minutes;
    [SerializeField]
    private TextMeshProUGUI seconds;
    [SerializeField]
    private TextMeshProUGUI centiseconds;
    private Coroutine decrementTimer;

    //Chrono where [0] = minutes, [1] = seconds, [2] = centiseconds
    [HideInInspector]
    public List<int> actualChrono;

    private void Awake()
    {
        // Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
        //
    }

    private void Start()
    {
        // Convert the time into minutes, seconds and centiseconds
        actualChrono = ConvertFloatIntoTime(time);

        minutes.SetText(ConvertToString(actualChrono[0]));
        seconds.SetText(ConvertToString(actualChrono[1]));
        centiseconds.SetText(ConvertToString(actualChrono[2]));
    }

    public void StartChrono()
    {
        decrementTimer = StartCoroutine(DecrementChrono());
    }

    private List<int> ConvertFloatIntoTime(float _time)
    {
        //Convert a float representing seconds into a list of minutes, seconds and centiseconds
        List<int> _timeValues = new();

        //Minutes
        _timeValues.Add(Mathf.FloorToInt(_time / 60f));
        //Seconds
        _timeValues.Add((int)(_time - (Mathf.FloorToInt(_time / 60f) * 60f)));
        //Centiseconds
        _timeValues.Add((int)(Math.Round(_time - Math.Truncate(_time), 2) * 100));

        return _timeValues;
    }

    private float ConvertTimeIntoFloat(List<int> _timeValues)
    {
        //Convert a list of minutes, seconds and centiseconds into a float representing seconds
        float _time = 0f;

        //Minutes
        _time += _timeValues[0] * 60;
        //Seconds
        _time += _timeValues[1];
        //Centiseconds
        _time += _timeValues[2] / 100f;

        return _time;
    }

    public List<int> ConvertAnActualChronoIntoATime(List<int> _actualChrono)
    {
        //return the chrono given into a real chrono
        //Example:
        //If chrono given is 0 minute, 45 seconds, 33 centiseconds
        //and if the chrono at the start is 1 minute, 36 seconds and 55 centiseconds
        //it will return 0 minute, 51 seconds and 22 centiseconds
        return ConvertFloatIntoTime(this.time - ConvertTimeIntoFloat(_actualChrono));
    }

    private string ConvertToString(int _time)
    {
        //Add a 0 before a value if it's less than 10
        if (_time >= 10)
        {
            return _time.ToString();
        }
        else
        {
            return $"{0}{_time}";
        }
    }

    private IEnumerator DecrementChrono()
    {
        yield return new WaitForSeconds(0.01f);

        // Decrement centiseconds
        // Decrement seconds when centiseconds are under 0
        // Decrement minutes when seconds are under 0
        // Stop the chrono if minutes, seconds and centiseconds are equals to 0
        if (actualChrono[2] - 1 == -1 && actualChrono[1] != 0)
        {
            //01 : 01 : 00
            actualChrono[2] = 99;
            actualChrono[1] -= 1;

            centiseconds.SetText(ConvertToString(actualChrono[2]));
            seconds.SetText(ConvertToString(actualChrono[1]));
            decrementTimer = StartCoroutine(DecrementChrono());
        }
        else if (actualChrono[2] - 1 == -1 && actualChrono[1] == 0 && actualChrono[0] != 0)
        {
            //01 : 00 : 00
            actualChrono[2] = 99;
            actualChrono[1] = 59;
            actualChrono[0] -= 1;

            centiseconds.SetText(ConvertToString(actualChrono[2]));
            seconds.SetText(ConvertToString(actualChrono[1]));
            minutes.SetText(ConvertToString(actualChrono[0]));
            decrementTimer = StartCoroutine(DecrementChrono());
        }
        else if (actualChrono[2] - 1 == -1 && actualChrono[1] == 0 && actualChrono[0] == 0)
        {
            //00 : 00 : 00
            StopTimer();
        }
        else
        {
            //01 : 01 : 01
            actualChrono[2] -= 1;
            centiseconds.SetText(ConvertToString(actualChrono[2]));
            decrementTimer = StartCoroutine(DecrementChrono());
        }
    }

    public void StopTimer()
    {
        // Stop the timer and finish the game if it's to 0
        StopCoroutine(decrementTimer);

        if (!RocketRideManager.Instance.gameIsOver)
        {
            EndOfTheGameWithChrono();
        }
    }

    private void EndOfTheGameWithChrono()
    {
        RocketRideManager.Instance.gameIsOver = true;
        RocketRideManager.Instance.GetRocketsWhichHaveNotFinished();
        StartCoroutine(WaitBeforeShowingPodium());
    }

    private IEnumerator WaitBeforeShowingPodium()
    {
        //Wait for 3 seconds before showing the results
        yield return new WaitForSeconds(3f);
        gameScreen.SetActive(false);
        podiumScreen.SetActive(true);
    }
}
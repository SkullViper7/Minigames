using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class RocketRideChronoManager : MonoBehaviour
{
    // Singleton
    private static RocketRideChronoManager _instance = null;
    private RocketRideChronoManager() { }
    public static RocketRideChronoManager Instance => _instance;
    //

    public float time;
    [SerializeField]
    private GameObject podiumScreen;
    [SerializeField]
    private GameObject gameScreen;

    [Header("ChronoTimer")]
    [SerializeField]
    private TextMeshProUGUI minutes;
    [SerializeField]
    private TextMeshProUGUI seconds;
    [SerializeField]
    private TextMeshProUGUI hundredthsOfSeconds;
    private Coroutine decrementTimer;

    [HideInInspector]
    public int nbrOfMinutes;
    [HideInInspector]
    public int nbrOfSeconds;
    [HideInInspector]
    public int nbrOfHundredthsOfSeconds;


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
        // Convert seconds into minutes, seconds and hundredths of seconds
        nbrOfMinutes = Mathf.FloorToInt(time / 60f);
        nbrOfSeconds = (int)(time - (Mathf.FloorToInt(time / 60f) * 60f));
        nbrOfHundredthsOfSeconds = 0;

        minutes.SetText(ConvertToString(nbrOfMinutes));
        seconds.SetText(ConvertToString(nbrOfSeconds));
        hundredthsOfSeconds.SetText(ConvertToString(nbrOfHundredthsOfSeconds));
    }

    public void StartChrono()
    {
        decrementTimer = StartCoroutine(DecrementChrono());
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

        // Decrement hundredths of seconds
        // Decrement seconds when hundredths of seconds are under 0
        // Decrement minutes when seconds are under 0
        // Stop the chrono if minutes, seconds and hundredths of seconds are equals to 0
        if (nbrOfHundredthsOfSeconds - 1 == -1 && nbrOfSeconds != 0)
        {
            //01 : 01 : 00
            nbrOfHundredthsOfSeconds = 99;
            nbrOfSeconds -= 1;

            hundredthsOfSeconds.SetText(ConvertToString(nbrOfHundredthsOfSeconds));
            seconds.SetText(ConvertToString(nbrOfSeconds));
            decrementTimer = StartCoroutine(DecrementChrono());
        }
        else if (nbrOfHundredthsOfSeconds - 1 == -1 && nbrOfSeconds == 0 && nbrOfMinutes != 0)
        {
            //01 : 00 : 00
            nbrOfHundredthsOfSeconds = 99;
            nbrOfSeconds = 59;
            nbrOfMinutes -= 1;

            hundredthsOfSeconds.SetText(ConvertToString(nbrOfHundredthsOfSeconds));
            seconds.SetText(ConvertToString(nbrOfSeconds));
            minutes.SetText(ConvertToString(nbrOfMinutes));
            decrementTimer = StartCoroutine(DecrementChrono());
        }
        else if (nbrOfHundredthsOfSeconds - 1 == -1 && nbrOfSeconds == 0 && nbrOfMinutes == 0)
        {
            //00 : 00 : 00
            StopTimer();
        }
        else
        {
            //01 : 01 : 01
            nbrOfHundredthsOfSeconds -= 1;
            hundredthsOfSeconds.SetText(ConvertToString(nbrOfHundredthsOfSeconds));
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